using Billing.Application.Commands;
using Billing.Application.Errors;
using Billing.Application.Queries;
using Billing.Application.Response;
using Billing.Controllers.Request.Invoice;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceCommands _commands;
        private readonly IInvoiceQueries _queries;

        public InvoicesController(
            IInvoiceCommands commands,
            IInvoiceQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        [HttpGet("{id}", Name = "GetInvoiceById")]
        public async Task<ActionResult<InvoiceResponse>> GetInvoiceById(Guid id)
        {
            InvoiceResponse? invoice = await _queries.GetByIdAsync(id);

            if (invoice is null)
                return NotFound();

            return Ok(invoice);
        }

        [HttpGet()]
        public async Task<ActionResult<List<InvoiceResponse>>> GetAllInvoices()
        {
            List<InvoiceResponse> invoices = await _queries.GetAllAsync();

            if (invoices is null || invoices.Count == 0)
                return NotFound();

            return Ok(invoices);
        }

        [HttpPost]
        public async Task<ActionResult> CreateInvoice([FromBody] CreateInvoiceRequest request)
        {
            Result<InvoiceResponse> result = await _commands.AddAsync(
                request.TenantId,
                request.LeasingAgreementId,
                request.ServicePeriodStartDate,
                request.ServicePeriodEndDate,
                request.DateDue,
                HttpContext.RequestAborted);

            if (result.IsFailed)
            {
                var error = result.Errors.First();

                return error switch
                {
                    NotFoundError => NotFound(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            InvoiceResponse newInvoice = result.Value;

            return CreatedAtRoute(nameof(GetInvoiceById), new { newInvoice.Id }, newInvoice);
        }

        [HttpPost("drafted/{id}")]
        public async Task<ActionResult> AddInvoiceLineItem(Guid id, [FromBody] AddInvoiceLineItemRequest request)
        {
            Result result = await _commands.AddInvoiceLineItemAsync(
                id,
                request.Description,
                request.Quantity,
                request.UnitPrice,
                request.Currency,
                HttpContext.RequestAborted);

            if(result.IsFailed)
            {
                var error = result.Errors.First();

                return error switch
                {
                    NotFoundError => NotFound(error.Message),
                    CannotAddLineItemToIssuedInvoiceError => Conflict(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok();
        }

        [HttpPost("issue/{id}")]
        public async Task<ActionResult> IssueInvoice(Guid id)
        {
            Result result = await _commands.IssueInvoiceAsync(id, HttpContext.RequestAborted);

            if (result.HasError<NotFoundError>(out var notFoundError))
                return NotFound(notFoundError.FirstOrDefault()?.Message);
            else if (result.HasError<BadRequestError>(out var badRequestError))
                return BadRequest(badRequestError.FirstOrDefault()?.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoice(Guid id)
        {
            Result result = await _commands.DeleteAsync(id, HttpContext.RequestAborted);

            if (result.HasError<NotFoundError>(out var notFoundError))
                return NotFound(notFoundError.FirstOrDefault()?.Message);
            else if (result.HasError<BadRequestError>(out var badRequestError))
                return BadRequest(badRequestError.FirstOrDefault()?.Message);

            return NoContent();
        }
    }
}
