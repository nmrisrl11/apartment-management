using AutoMapper;
using AutoMapper.Execution;
using FluentResults;
using Leasing.Application.Commands;
using Leasing.Application.Errors;
using Leasing.Domain.Entities;
using Leasing.Domain.Exceptions;
using Leasing.Domain.Repositories;
using Leasing.Domain.Services;
using Leasing.Domain.ValueObjects;
using System.Net;

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

        public async Task<Result> AddAsync(
            string tenantName,
            string tenantEmail,
            string tenantContactNumber,
            Guid ownerId,
            Guid apartmentId,
            CancellationToken cancellationToken)
        {
            try
            {
                Owner? owner = await _unitOfWork.Owners.GetByIdAsync(new OwnerId(ownerId));

                if (owner is null)
                    return Result.Fail(new NotFoundError($"Owner with id: {apartmentId} is not found."));

                Apartment? apartmentToLease = await _unitOfWork.Apartments.GetByIdAsync(new ApartmentId(apartmentId));

                if (apartmentToLease is null)
                    return Result.Fail(new NotFoundError($"Apartment with id: {apartmentId} is not found."));

                var leasingAgreementService = new LeasingAgreementService();
                (LeasingAgreement leasingAgreement, LeasingRecord leasingRecord) = leasingAgreementService.CreateLeasingAgreement(
                    tenantName,
                    tenantEmail,
                    tenantContactNumber,
                    owner,
                    apartmentToLease);              

                await _unitOfWork.LeasingAgreements.AddAsync(leasingAgreement);
                await _unitOfWork.LeasingRecords.AddAsync(leasingRecord);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Ok();
            }
            catch (ApartmentIsCurrentlyUnderMaintenanceException ex)
            {
                return Result.Fail(new ApartmentIsCurrentlyUnderMaintenanceError(ex.Message));
            }
            catch (ApartmentAlreadyOccupiedException ex)
            {
                return Result.Fail(new ApartmentAlreadyOccupiedError(ex.Message));
            }           
        }

        public async Task<Result> RenewAsync(
            Guid leasingAgreementId,
            Guid tenantId,
            Guid ownerId,
            Guid apartmentId,
            CancellationToken cancellationToken)
        {
            LeasingAgreement? leasingAgreementToRenew = await _unitOfWork.LeasingAgreements.GetByIdAsync(new LeasingAgreementId(leasingAgreementId));
            if (leasingAgreementToRenew is null)
                return Result.Fail(new NotFoundError($"Leasing Agreement with id: {leasingAgreementId} is not found."));

            Tenant? tenant = await _unitOfWork.Tenants.GetByIdAsync(new TenantId(tenantId));
            if (tenant is null)
                return Result.Fail(new NotFoundError($"Tenant with id: {apartmentId} is not found."));

            Owner? owner = await _unitOfWork.Owners.GetByIdAsync(new OwnerId(ownerId));
            if (owner is null)
                return Result.Fail(new NotFoundError($"Owner with id: {apartmentId} is not found."));

            Apartment? apartmentToLease = await _unitOfWork.Apartments.GetByIdAsync(new ApartmentId(apartmentId));
            if (apartmentToLease is null)
                return Result.Fail(new NotFoundError($"Apartment with id: {apartmentId} is not found."));

            LeasingRecord? leasingRecord = await _unitOfWork.LeasingRecords.GetByIdsAsync(new TenantId(tenantId), new OwnerId(ownerId), new ApartmentId(apartmentId));

            if (leasingRecord is null)
                return Result.Fail(new NotFoundError($"Leasing Record not found for tenant {tenantId}, owner {ownerId} and apartment {apartmentId}."));

            var leasingAgreementService = new LeasingAgreementService();
            leasingAgreementService.RenewLeasingAgreement(leasingAgreementToRenew, leasingRecord);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
