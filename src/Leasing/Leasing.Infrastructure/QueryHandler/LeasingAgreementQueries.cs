using AutoMapper;
using AutoMapper.QueryableExtensions;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leasing.Infrastructure.QueryHandler
{
    public class LeasingAgreementQueries : ILeasingAgreementQueries
    {
        private readonly LeasingDbContext _context;
        private readonly IMapper _mapper;

        public LeasingAgreementQueries(LeasingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LeasingAgreementResponse>> GetAllAsync()
        {
            return await _context.LeasingAgreements
                .ProjectTo<LeasingAgreementResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<LeasingAgreementResponse?> GetByIdAsync(Guid id)
        {
            return await _context.LeasingAgreements
                .Where(la => la.Id == new LeasingAgreementId(id))
                .ProjectTo<LeasingAgreementResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
