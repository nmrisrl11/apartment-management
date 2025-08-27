using AutoMapper;
using AutoMapper.QueryableExtensions;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.QueryHandler
{
    public class LessorQueries : ILessorQueries
    {
        private readonly LeasingDbContext _context;
        private readonly IMapper _mapper;

        public LessorQueries(LeasingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LessorResponse>> GetAllAsync()
        {
            return await _context.Lessors
                .ProjectTo<LessorResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<LessorResponse?> GetByIdAsync(Guid id)
        {
            return await _context.Lessors
                .Where(l => l.Id == new LessorId(id))
                .ProjectTo<LessorResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
