using ApartmentManagement.Contracts.Services;
using AutoMapper;
using FluentResults;
using Ownership.Application.Commands;
using Ownership.Application.Errors;
using Ownership.Application.Response;
using Ownership.Domain.Entities;
using Ownership.Domain.Repositories;
using Ownership.Domain.ValueObjects;

namespace Ownership.Application.CommandHandler
{
    public class OwnerCommands : IOwnerCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public OwnerCommands(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDomainEventPublisher domainEventPublisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _domainEventPublisher = domainEventPublisher;
        }

        public async Task<OwnerResponse> AddAsync(string name, CancellationToken cancellationToken)
        {
            Owner ownerToCreate = Owner.Create(name);
            await _unitOfWork.Owners.AddAsync(ownerToCreate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _domainEventPublisher.PublishAsync(ownerToCreate.DomainEvents, cancellationToken);

            return _mapper.Map<OwnerResponse>(ownerToCreate);
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            Owner? ownerToDelete = await _unitOfWork.Owners.GetByIdAsync(new OwnerId(id));

            if (ownerToDelete is null)
                return Result.Fail(new NotFoundError($"Owner with id: {id} is not found."));

            _unitOfWork.Owners.DeleteAsync(ownerToDelete);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }

        public async Task<Result> UpdateAsync(Guid id, string name, CancellationToken cancellationToken)
        {
            Owner? ownerToUpdate = await _unitOfWork.Owners.GetByIdAsync(new OwnerId(id));

            if (ownerToUpdate is null)
                return Result.Fail(new NotFoundError($"Owner with id: {id} is not found."));

            ownerToUpdate.Update(name);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
