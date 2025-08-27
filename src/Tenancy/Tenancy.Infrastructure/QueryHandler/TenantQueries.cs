using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Tenancy.Application.Queries;
using Tenancy.Application.Response;
using Tenancy.Domain.ValueObjects;
using Tenancy.Infrastructure.Data;

namespace Tenancy.Infrastructure.QueryHandler
{
    public class TenantQueries : ITenantQueries
    {
        private readonly TenancyDbContext _context;
        private readonly IMapper _mapper;

        public TenantQueries(TenancyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TenantResponse>> GetAllAsync()
        {
            return await _context.Tenants
                .ProjectTo<TenantResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
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
