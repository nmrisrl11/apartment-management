using AutoMapper;
using FluentResults;
using Leasing.Application.Commands;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;

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

        public async Task<Result<ApartmentResponse>> AddAsync(Guid id, Guid lessorId, string buildingNumber, string apartmentNumber, CancellationToken cancellationToken)
        {
            Apartment apartment = Apartment.Create(id, lessorId, buildingNumber, apartmentNumber);
            await _unitOfWork.Apartments.AddAsync(apartment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok(_mapper.Map<ApartmentResponse>(apartment));
        }
    }
}
