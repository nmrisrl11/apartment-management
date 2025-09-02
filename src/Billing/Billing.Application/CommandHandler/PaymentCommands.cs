using AutoMapper;
using Billing.Application.Commands;
using Billing.Application.Errors;
using Billing.Application.Response;
using Billing.Domain.Entities;
using Billing.Domain.Enums;
using Billing.Domain.Exceptions;
using Billing.Domain.Repositories;
using Billing.Domain.ValueObjects;
using FluentResults;

namespace Billing.Application.CommandHandler
{
    public class PaymentCommands : IPaymentCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PaymentResponse>> AddAsync(
            Guid invoiceId,
            decimal amount,
            string currency,
            string method,
            string transactionReference,
            CancellationToken cancellationToken)
        {
            try
            {
                var InvoiceID = new InvoiceId(invoiceId);
                var AmountToPay = new Money(amount, currency);
                var PaymentMethod = Enum.Parse<PaymentMethod>(method, true);

                Invoice? invoice = await _unitOfWork.Invoices.GetByIdAsync(InvoiceID);

                if (invoice is null)
                    return Result.Fail(new NotFoundError($"Invoice with id: {invoiceId} is not found."));

                Payment payment = Payment.Create(invoice, AmountToPay, PaymentMethod, transactionReference);

                payment.MarkAsSucceeded(DateTime.UtcNow);
                invoice.ApplyPayment(payment.Amount);

                await _unitOfWork.Payments.AddAsync(payment);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Ok(_mapper.Map<PaymentResponse>(payment));
            }
            catch(InvoiceIsEmptyException ex)
            {
                return Result.Fail(new InvoiceIsEmptyError(ex.Message));
            }
            catch(InvalidPaymentException ex)
            {
                return Result.Fail(new InvalidPaymentError(ex.Message));
            }
            catch(CannotMarkAsSucceededException ex)
            {
                return Result.Fail(new CannotMarkAsSucceededError(ex.Message));
            }
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            Payment? paymentToDelete = await _unitOfWork.Payments.GetByIdAsync(new PaymentId(id));

            if (paymentToDelete is null)
                return Result.Fail(new NotFoundError($"Payment with id: {id} is not found."));

            _unitOfWork.Payments.DeleteAsync(paymentToDelete);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
