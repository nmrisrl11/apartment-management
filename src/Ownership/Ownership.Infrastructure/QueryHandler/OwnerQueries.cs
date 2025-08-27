using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Ownership.Application.Queries;
using Ownership.Application.Response;
using Ownership.Domain.ValueObjects;
using Ownership.Infrastructure.Data;

namespace Ownership.Infrastructure.QueryHandler
{
    public class OwnerQueries : IOwnerQueries
    {
        private readonly OwnershipDbContext _context;
        private readonly IMapper _mapper;

        public OwnerQueries(OwnershipDbContext context, IMapper mapper)
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
