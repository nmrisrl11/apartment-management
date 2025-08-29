using ApartmentManagement.Contracts.Services;
using AutoMapper;
using FluentResults;
using Property.Application.Commands;
using Property.Application.Errors;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.Exceptions;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Application.CommandHandler
{
    public class ApartmentUnitCommands : IApartmentUnitCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public ApartmentUnitCommands(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDomainEventPublisher domainEventPublisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _domainEventPublisher = domainEventPublisher;
        }

        public async Task<Result<ApartmentUnitResponse>> AddAsync(
            Guid ownerId,
            string buildingNumber,
            string apartmentNumber,
            CancellationToken cancellationToken)
        {
            Owner? owner = await _unitOfWork.Owners.GetByIdAsync(new OwnerId(ownerId));

            if (owner is null)
                return Result.Fail(new NotFoundError($"Owner with id: {ownerId} is not found."));

            ApartmentUnit apartmentUnitToCreate = ApartmentUnit.Create(
                new OwnerId(ownerId),
                buildingNumber,
                apartmentNumber);
            await _unitOfWork.ApartmentUnits.AddAsync(apartmentUnitToCreate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _domainEventPublisher.PublishAsync(apartmentUnitToCreate.DomainEvents, cancellationToken);

            return Result.Ok(_mapper.Map<ApartmentUnitResponse>(apartmentUnitToCreate));
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            ApartmentUnit? apartmentUnitToDelete = await _unitOfWork.ApartmentUnits.GetByIdAsync(new ApartmentUnitId(id));

            if (apartmentUnitToDelete is null)
                return Result.Fail(new NotFoundError($"Apartment Unit with id: {id} is not found."));

            _unitOfWork.ApartmentUnits.DeleteAsync(apartmentUnitToDelete);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }

        public async Task<Result> FinishUnderMaintenanceAsync(
            Guid apartmentId,
            CancellationToken cancellationToken)
        {
            try
            {
                ApartmentUnit? apartmentUnit = await _unitOfWork.ApartmentUnits.GetByIdAsync(new ApartmentUnitId(apartmentId));

                if (apartmentUnit is null)
                    return Result.Fail(new NotFoundError($"Apartment Unit  with id: {apartmentId} is not found."));

                apartmentUnit.FinishUnderMaintenance();
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _domainEventPublisher.PublishAsync(apartmentUnit.DomainEvents, cancellationToken);
                return Result.Ok();
            } 
            catch (ApartmentUnitIsNotUnderMaintenanceException ex)
            {
                return Result.Fail(new ApartmentUnitIsNotUnderMaintenanceError(ex.Message));
            }
        }

        public async Task<Result> StartUnderMaintenanceAsync(
            Guid apartmentId,
            CancellationToken cancellationToken)
        {
            try
            {
                ApartmentUnit? apartmentUnit = await _unitOfWork.ApartmentUnits.GetByIdAsync(new ApartmentUnitId(apartmentId));

                if (apartmentUnit is null)
                    return Result.Fail(new NotFoundError($"Apartment Unit  with id: {apartmentId} is not found."));

                apartmentUnit.StartUnderMaintenance();
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _domainEventPublisher.PublishAsync(apartmentUnit.DomainEvents, cancellationToken);

                return Result.Ok();
            }
            catch(ApartmentUnitIsCurrentlyOccupiedException ex)
            {
                return Result.Fail(new ApartmentUnitIsCurrentlyOccupiedError(ex.Message));
            }
            catch (ApartmentUnitAlreadyUnderMaintenanceException ex)
            {
                return Result.Fail(new ApartmentUnitAlreadyUnderMaintenanceError(ex.Message));
            }
        }

        public async Task<Result> UpdateAsync(
            Guid id,
            string buildingNumber,
            string apartmentNumber,
            CancellationToken cancellationToken)
        {
            ApartmentUnit? apartmentUnitToUpdate = await _unitOfWork.ApartmentUnits.GetByIdAsync(new ApartmentUnitId(id));

            if (apartmentUnitToUpdate is null)
                return Result.Fail(new NotFoundError($"Apartment Unit  with id: {id} is not found."));

            apartmentUnitToUpdate.Update(buildingNumber, apartmentNumber);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
