using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Domain.ValueObjects;
using Property.Infrastructure.Data;

namespace Property.Infrastructure.QueryHandler
{
    public class ApartmentUnitQueries : IApartmentUnitQueries
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;

        public ApartmentUnitQueries(PropertyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ApartmentUnitResponse>> GetAllAsync()
        {
            return await _context.ApartmentUnits
                .ProjectTo<ApartmentUnitResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ApartmentUnitResponse?> GetByIdAsync(Guid id)
        {
            return await _context.ApartmentUnits
                .Where(au => au.Id == new ApartmentUnitId(id))
                .ProjectTo<ApartmentUnitResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
