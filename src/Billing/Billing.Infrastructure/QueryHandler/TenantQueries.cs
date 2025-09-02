using AutoMapper;
using AutoMapper.QueryableExtensions;
using Billing.Application.Queries;
using Billing.Application.Response;
using Billing.Domain.ValueObjects;
using Billing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.QueryHandler
{
    public class TenantQueries : ITenantQueries
    {
        private readonly BillingDbContext _context;
        private readonly IMapper _mapper;

        public TenantQueries(BillingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TenantResponse>> GetAllAsync()
        {
            return await _context.Tenants.ProjectTo<TenantResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<TenantResponse?> GetByIdAsync(Guid id)
        {
            return await _context.Tenants
                .Where(t => t.Id == new TenantId(id))
                .ProjectTo<TenantResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
