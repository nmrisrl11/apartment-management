using AutoMapper;
using AutoMapper.QueryableExtensions;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.QueryHandler
{
    public class LesseeQueries : ILesseeQueries
    {
        private readonly LeasingDbContext _context;
        private readonly IMapper _mapper;

        public LesseeQueries(LeasingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LesseeResponse>> GetAllAsync()
        {
            return await _context.Lessees.ProjectTo<LesseeResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<LesseeResponse?> GetByIdAsync(Guid id)
        {
            return await _context.Lessees
                .Where(l => l.Id == new LesseeId(id))
                .ProjectTo<LesseeResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
