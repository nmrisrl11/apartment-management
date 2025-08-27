using ApartmentManagement.Contracts.Services;
using AutoMapper;
using FluentResults;
using Tenancy.Application.Commands;
using Tenancy.Application.Errors;
using Tenancy.Application.Response;
using Tenancy.Domain.Entities;
using Tenancy.Domain.Repositories;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Application.CommandHandler
{
    public class TenantCommands : ITenantCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public TenantCommands(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDomainEventPublisher domainEventPublisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _domainEventPublisher = domainEventPublisher;
        }

        public async Task<TenantResponse> AddAsync(
            string name,
            string email,
            string contactNumber,
            CancellationToken cancellationToken)
        {
            Tenant tenantToCreate = Tenant.Create(name, email, contactNumber);
            await _unitOfWork.Tenants.AddAsync(tenantToCreate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _domainEventPublisher.PublishAsync(tenantToCreate.DomainEvents, cancellationToken);

            return _mapper.Map<TenantResponse>(tenantToCreate);
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            Tenant? tenantToDelete = await _unitOfWork.Tenants.GetByIdAsync(new TenantId(id));

            if (tenantToDelete is null)
                return Result.Fail(new NotFoundError($"Tenant with id: {id} is not found."));

            _unitOfWork.Tenants.DeleteAsync(tenantToDelete);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }

        public async Task<Result> UpdateAsync(
            Guid id,
            string name,
            string email,
            string contactNumber,
            CancellationToken cancellationToken)
        {
            Tenant? tenantToUpdate = await _unitOfWork.Tenants.GetByIdAsync(new TenantId(id));

            if (tenantToUpdate is null)
                return Result.Fail(new NotFoundError($"Tenant with id: {id} is not found."));

            tenantToUpdate.Update(name, email, contactNumber);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
