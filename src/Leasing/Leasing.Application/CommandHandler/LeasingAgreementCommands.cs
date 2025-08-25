using AutoMapper;
using Leasing.Application.Commands;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.Exceptions;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.CommandHandler
{
    public class LeasingAgreementCommands : ILeasingAgreementCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeasingAgreementCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LeasingAgreementResponse> AddAsync(
            string tenantName,
            string tenantEmail,
            string tenantContactNumber,
            Guid ownerId,
            Guid apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal,
            CancellationToken cancellationToken)
        {
            Apartment? apartmentToLease = await _unitOfWork.Apartments.GetByIdAsync(new ApartmentId(apartmentId));

            if (apartmentToLease is null)
                throw new ApartmentNotFoundException($"Apartment with id: {apartmentId} is not found.");

            apartmentToLease.MarkAsOccupied();

            // 1. Domain logic: Create the new LeasingAgreement
            LeasingAgreement newLeasingAgreement = LeasingAgreement.Create(
                tenantName,
                tenantEmail,
                tenantContactNumber,
                new OwnerId(ownerId),
                new ApartmentId(apartmentId),
                dateLeased,
                dateRenewal);

            await _unitOfWork.LeasingAgreements.AddAsync(newLeasingAgreement);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LeasingAgreementResponse>(newLeasingAgreement);
        }
    }
}
