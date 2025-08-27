using AutoMapper;
using AutoMapper.QueryableExtensions;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.QueryHandler
{
    public class TenantQueries : ITenantQueries
    {
        private readonly LeasingDbContext _context;
        private readonly IMapper _mapper;

        public TenantQueries(LeasingDbContext context, IMapper mapper)
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
