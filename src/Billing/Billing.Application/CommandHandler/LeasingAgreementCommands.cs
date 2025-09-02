using AutoMapper;
using Billing.Application.Commands;
using Billing.Application.Response;
using Billing.Domain.Entities;
using Billing.Domain.Repositories;

namespace Billing.Application.CommandHandler
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
            Guid id,
            CancellationToken cancellationToken)
        {
            LeasingAgreement leasingAgreementToCreate = LeasingAgreement.Create(id);
            await _unitOfWork.LeasingAgreements.AddAsync(leasingAgreementToCreate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LeasingAgreementResponse>(leasingAgreementToCreate);
        }
    }
}
