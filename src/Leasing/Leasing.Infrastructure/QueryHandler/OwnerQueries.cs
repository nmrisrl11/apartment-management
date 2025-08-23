using AutoMapper;
using AutoMapper.QueryableExtensions;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.QueryHandler
{
    public class OwnerQueries : IOwnerQueries
    {
        private readonly LeasingDbContext _context;
        private readonly IMapper _mapper;

        public OwnerQueries(LeasingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OwnerResponse>> GetAllAsync()
        {
            return await _context.Owners
                .ProjectTo<OwnerResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<OwnerResponse?> GetByIdAsync(Guid id)
        {
            return await _context.Owners
                .Where(o => o.Id == new OwnerId(id))
                .ProjectTo<OwnerResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
