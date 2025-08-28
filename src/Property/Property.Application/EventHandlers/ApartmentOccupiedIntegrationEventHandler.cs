using Leasing.IntegrationEvent;
using MediatR;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Application.EventHandlers
{
    public class ApartmentOccupiedIntegrationEventHandler : INotificationHandler<ApartmentOccupiedIntegrationEvent>
    {
        private readonly IApartmentUnitRepository _apartmentUnitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentOccupiedIntegrationEventHandler(
            IApartmentUnitRepository apartmentUnitRepository,
            IUnitOfWork unitOfWork)
        {
            _apartmentUnitRepository = apartmentUnitRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(ApartmentOccupiedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var apartmentUnit = await _apartmentUnitRepository.GetByIdAsync(new ApartmentUnitId(notification.Id));

            if (apartmentUnit is null)
                return;

            apartmentUnit.MarkAsLeased();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
