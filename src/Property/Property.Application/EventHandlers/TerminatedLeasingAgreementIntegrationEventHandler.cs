using Leasing.IntegrationEvent;
using MediatR;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Application.EventHandlers
{
    public class TerminatedLeasingAgreementIntegrationEventHandler : INotificationHandler<TerminatedLeasingAgreementIntegrationEvent>
    {
        private readonly IApartmentUnitRepository _apartmentUnitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TerminatedLeasingAgreementIntegrationEventHandler(
            IApartmentUnitRepository apartmentUnitRepository,
            IUnitOfWork unitOfWork)
        {
            _apartmentUnitRepository = apartmentUnitRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(TerminatedLeasingAgreementIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var apartmentUnit = await _apartmentUnitRepository.GetByIdAsync(new ApartmentUnitId(notification.Id));

            if (apartmentUnit is null)
                return;

            apartmentUnit.MarkAsVacant();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
