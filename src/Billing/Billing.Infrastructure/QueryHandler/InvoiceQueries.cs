using AutoMapper;
using AutoMapper.QueryableExtensions;
using Billing.Application.Queries;
using Billing.Application.Response;
using Billing.Domain.ValueObjects;
using Billing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.QueryHandler
{
    public class InvoiceQueries : IInvoiceQueries
    {
        private readonly BillingDbContext _context;
        private readonly IMapper _mapper;

        public InvoiceQueries(BillingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<InvoiceResponse>> GetAllAsync()
        {
            return await _context.Invoices
                .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<InvoiceResponse?> GetByIdAsync(Guid id)
        {
            return await _context.Invoices
                .Where(i => i.Id == new InvoiceId(id))
                .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
