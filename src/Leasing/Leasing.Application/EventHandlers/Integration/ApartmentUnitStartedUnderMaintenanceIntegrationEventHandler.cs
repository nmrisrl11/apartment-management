using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using MediatR;
using Property.IntegrationEvent;

namespace Leasing.Application.EventHandlers.Integration
{
    public class ApartmentUnitStartedUnderMaintenanceIntegrationEventHandler : INotificationHandler<ApartmentUnitStartedUnderMaintenanceIntegrationEvent>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentUnitStartedUnderMaintenanceIntegrationEventHandler(
            IApartmentRepository apartmentRepository,
            IUnitOfWork unitOfWork)
        {
            _apartmentRepository = apartmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ApartmentUnitStartedUnderMaintenanceIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var apartmentUnit = await _apartmentRepository.GetByIdAsync(new ApartmentId(notification.Id));

            if (apartmentUnit is null)
                return;

            apartmentUnit.MarkAsUnavailable();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
