using AutoMapper;
using FluentResults;
using Leasing.Application.Commands;
using Leasing.Application.Errors;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.CommandHandler
{
    public class OwnerCommands : IOwnerCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OwnerCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OwnerResponse> AddAsync(string name, CancellationToken cancellationToken)
        {
            Owner ownerToCreate = Owner.Create(name);
            await _unitOfWork.Owners.AddAsync(ownerToCreate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

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
