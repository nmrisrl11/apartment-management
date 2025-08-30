using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using MediatR;
using Property.IntegrationEvent;

namespace Leasing.Application.EventHandlers.Integration
{
    public class ApartmentUnitFinishedUnderMaintenanceIntegrationEventHandler : INotificationHandler<ApartmentUnitFinishedUnderMaintenanceIntegrationEvent>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentUnitFinishedUnderMaintenanceIntegrationEventHandler(
            IApartmentRepository apartmentRepository,
            IUnitOfWork unitOfWork)
        {
            _apartmentRepository = apartmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ApartmentUnitFinishedUnderMaintenanceIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var apartmentUnit = await _apartmentRepository.GetByIdAsync(new ApartmentId(notification.Id));

            if (apartmentUnit is null)
                return;

            apartmentUnit.MarkAsAvailable();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
