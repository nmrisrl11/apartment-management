using ApartmentManagement.Contracts.Services;
using AutoMapper;
using Billing.Application.Commands;
using Billing.Application.Errors;
using Billing.Application.Response;
using Billing.Domain.Entities;
using Billing.Domain.Exceptions;
using Billing.Domain.Repositories;
using Billing.Domain.ValueObjects;
using FluentResults;

namespace Billing.Application.CommandHandler
{
    public class InvoiceCommands : IInvoiceCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public InvoiceCommands(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDomainEventPublisher domainEventPublisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _domainEventPublisher = domainEventPublisher;
        }
        public async Task<Result<InvoiceResponse>> AddAsync(
            Guid tenantId,
            Guid leasingAgreementId,
            DateTime ServicePeriodStartDate,
            DateTime ServicePeriodEndDate,
            DateTime DateDue,
            CancellationToken cancellationToken)
        {
            // Todo: Add the checking of TenantId and LeasingAgreementId here

            var TenantId = new TenantId(tenantId);
            var LeasingAgreementId = new LeasingAgreementId(leasingAgreementId);
            var ServicePeriod = new DateRange(ServicePeriodStartDate, ServicePeriodEndDate);

            Invoice invoiceToCreate = Invoice.Create(TenantId, LeasingAgreementId, ServicePeriod, DateDue);

            await _unitOfWork.Invoices.AddAsync(invoiceToCreate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok(_mapper.Map<InvoiceResponse>(invoiceToCreate));
        }

        public async Task<Result> AddInvoiceLineItemAsync(
            Guid invoiceId,
            string description,
            decimal quantity,
            decimal unitPrice,
            string currency,
            CancellationToken cancellationToken)
        {
            try
            {
                Invoice? invoice = await _unitOfWork.Invoices.GetByIdAsync(new InvoiceId(invoiceId));

                if (invoice is null)
                    return Result.Fail(new NotFoundError($"Invoice with id: {invoiceId} is not found."));

                var unitPriceAsMoney = new Money(unitPrice, currency);

                invoice.AddLineItem(new InvoiceId(invoiceId), description, quantity, unitPriceAsMoney);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Ok();

            }
            catch(CannotAddLineItemToIssuedInvoiceException ex)
            {
                return Result.Fail(new CannotAddLineItemToIssuedInvoiceError(ex.Message));
            }
        }

        public async Task<Result> DeleteAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            Invoice? invoiceToDelete = await _unitOfWork.Invoices.GetByIdAsync(new InvoiceId(id));

            if(invoiceToDelete is null)
                return Result.Fail(new NotFoundError($"Invoice with id: {id} is not found."));

            _unitOfWork.Invoices.DeleteAsync(invoiceToDelete);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }

        public async Task<Result> IssueInvoiceAsync(Guid invoiceId, CancellationToken cancellationToken)
        {           
            try
            {
                Invoice? invoiceToIssue = await _unitOfWork.Invoices.GetByIdAsync(new InvoiceId(invoiceId));

                if (invoiceToIssue is null)
                    return Result.Fail(new NotFoundError($"Invoice with id: {invoiceId} is not found."));

                invoiceToIssue.Issue();
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Ok();
            }
            catch(CannotIssueNonDraftInvoiceException ex)
            {
                return Result.Fail(new CannotIssueNonDraftInvoiceError(ex.Message));
            }
        }
    }
}
