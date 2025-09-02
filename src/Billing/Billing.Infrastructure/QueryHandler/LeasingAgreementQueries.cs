using AutoMapper;
using AutoMapper.QueryableExtensions;
using Billing.Application.Queries;
using Billing.Application.Response;
using Billing.Domain.ValueObjects;
using Billing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.QueryHandler
{
    public class LeasingAgreementQueries : ILeasingAgreementQueries
    {
        private readonly BillingDbContext _context;
        private readonly IMapper _mapper;

        public LeasingAgreementQueries(BillingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LeasingAgreementResponse>> GetAllAsync()
        {
            return await _context.LeasingAgreements.ProjectTo<LeasingAgreementResponse>(_mapper.ConfigurationProvider).ToListAsync();
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
