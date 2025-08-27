using AutoMapper;
using FluentResults;
using Leasing.Application.Commands;
using Leasing.Application.Errors;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.Enums;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.CommandHandler
{
    public class ApartmentCommands : IApartmentCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApartmentCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ApartmentResponse>> AddAsync(Guid lessorId, string buildingNumber, string apartmentNumber, CancellationToken cancellationToken)
        {
            Lessor? lessor = await _unitOfWork.Lessors.GetByIdAsync(new LessorId(lessorId));

            if (lessor is null)
                return Result.Fail(new NotFoundError($"Lessor with id: {lessorId} is not found."));

            Apartment apartment = Apartment.Create(
                new LessorId(lessorId),
                buildingNumber,
                apartmentNumber);

            await _unitOfWork.Apartments.AddAsync(apartment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok(_mapper.Map<ApartmentResponse>(apartment));
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            Apartment? apartmentToDelete = await _unitOfWork.Apartments.GetByIdAsync(new ApartmentId(id));

            if (apartmentToDelete is null)
                return Result.Fail(new NotFoundError($"Apartment with id: {id} is not found."));

            if (apartmentToDelete.Status == ApartmentStatus.OCCUPIED)
                return Result.Fail(new BadRequestError("Deletion of apartment is not allowed as it is currently occupied."));

            _unitOfWork.Apartments.DeleteAsync(apartmentToDelete);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }

        public async Task<Result> UpdateAsync(Guid id, string buildingNumber, string apartmentNumber, CancellationToken cancellationToken)
        {
            Apartment? apartmentToUpdate = await _unitOfWork.Apartments.GetByIdAsync(new ApartmentId(id));

            if (apartmentToUpdate is null)
                return Result.Fail(new NotFoundError($"Apartment with id: {id} is not found."));

            apartmentToUpdate.Update(buildingNumber, apartmentNumber);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
