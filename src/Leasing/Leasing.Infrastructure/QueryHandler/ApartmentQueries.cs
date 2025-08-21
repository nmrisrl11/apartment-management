using AutoMapper;
using AutoMapper.QueryableExtensions;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.QueryHandler
{
    public class ApartmentQueries : IApartmentQueries
    {
        private readonly LeasingDbContext _context;
        private readonly IMapper _mapper;

        public ApartmentQueries(LeasingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ApartmentResponse>> GetAllAsync()
        {
            return await _context.Apartments
                .ProjectTo<ApartmentResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ApartmentResponse?> GetByIdAsync(Guid id)
        {
            return await _context.Apartments
                .Where(a => a.Id == new ApartmentId(id))
                .ProjectTo<ApartmentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
