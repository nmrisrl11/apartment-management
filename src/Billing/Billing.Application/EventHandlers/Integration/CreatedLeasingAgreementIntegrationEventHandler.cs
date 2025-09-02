using Billing.Application.Commands;
using Billing.Domain.Repositories;
using Leasing.IntegrationEvent;
using MediatR;

namespace Billing.Application.EventHandlers.Integration
{
    public class CreatedLeasingAgreementIntegrationEventHandler : INotificationHandler<CreatedLeasingAgreementIntegrationEvent>
    {
        private readonly ILeasingAgreementCommands _leasingAgreementCommands;
        private readonly IUnitOfWork _unitOfWork;

        public CreatedLeasingAgreementIntegrationEventHandler(
            ILeasingAgreementCommands leasingAgreementCommands,
            IUnitOfWork unitOfWork)
        {
            _leasingAgreementCommands = leasingAgreementCommands;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreatedLeasingAgreementIntegrationEvent notification, CancellationToken cancellationToken)
        {
            
            await _leasingAgreementCommands.AddAsync(notification.LeasingAgreementId, cancellationToken);
        }
    }
}
