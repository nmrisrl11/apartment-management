using AutoMapper;
using Billing.Application.Commands;
using Billing.Application.Response;
using Billing.Domain.Entities;
using Billing.Domain.Repositories;

namespace Billing.Application.CommandHandler
{
    public class TenantCommands : ITenantCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TenantCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TenantResponse> AddAsync(
            Guid id,
            string name,
            CancellationToken cancellationToken)
        {
            Tenant tenantToCreate = Tenant.Create(id, name);
            await _unitOfWork.Tenants.AddAsync(tenantToCreate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TenantResponse>(tenantToCreate);
        }
    }
}
