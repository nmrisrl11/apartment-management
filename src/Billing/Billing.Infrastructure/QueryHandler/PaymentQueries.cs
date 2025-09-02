using AutoMapper;
using AutoMapper.QueryableExtensions;
using Billing.Application.Queries;
using Billing.Application.Response;
using Billing.Domain.ValueObjects;
using Billing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.QueryHandler
{
    public class PaymentQueries : IPaymentQueries
    {
        private readonly BillingDbContext _context;
        private readonly IMapper _mapper;

        public PaymentQueries(BillingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PaymentResponse>> GetAllAsync()
        {
            return await _context.Payments
                .ProjectTo<PaymentResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PaymentResponse?> GetByIdAsync(Guid id)
        {
            return await _context.Payments
                .Where(p => p.Id == new PaymentId(id))
                .ProjectTo<PaymentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
