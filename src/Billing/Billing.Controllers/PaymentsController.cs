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
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentCommands _commands;
        private readonly IPaymentQueries _queries;

        public PaymentsController(
            IPaymentCommands commands,
            IPaymentQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        [HttpGet("{id}", Name = "GetPaymentById")]
        public async Task<ActionResult<PaymentResponse>> GetPaymentById(Guid id)
        {
            PaymentResponse? payment = await _queries.GetByIdAsync(id);

            if (payment is null)
                return NotFound();

            return Ok(payment);
        }

        [HttpGet()]
        public async Task<ActionResult<List<PaymentResponse>>> GetAllPayments()
        {
            List<PaymentResponse> payments = await _queries.GetAllAsync();

            if (payments is null || payments.Count == 0)
                return NotFound();

            return Ok(payments);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentResponse>> CreateInvoice([FromBody] CreatePaymentRequest request)
        {
            Result<PaymentResponse> result = await _commands.AddAsync(
                request.InvoiceId,
                request.Amount,
                request.Currency,
                request.Method,
                request.TransactionReference,
                HttpContext.RequestAborted);

            if (result.IsFailed)
            {
                var error = result.Errors.First();

                return error switch
                {
                    NotFoundError => NotFound(error.Message),
                    InvoiceIsEmptyError => Conflict(error.Message),
                    InvoiceIsNotYetIssuedError => Conflict(error.Message),
                    InvoiceAlreadyPaidError => Conflict(error.Message),
                    InvalidPaymentError => Conflict(error.Message),
                    CannotMarkAsSucceededError => Conflict(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            PaymentResponse newPayment = result.Value;

            return CreatedAtRoute(nameof(GetPaymentById), new { newPayment.Id }, newPayment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayment(Guid id)
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
