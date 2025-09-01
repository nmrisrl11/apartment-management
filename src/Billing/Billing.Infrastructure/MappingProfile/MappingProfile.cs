using AutoMapper;
using Billing.Application.Response;
using Billing.Domain.Entities;

namespace Billing.Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Invoice
            CreateMap<Invoice, InvoiceResponse>()
                .ForMember(i => i.Id, options => options.MapFrom(i => i.Id.Value))
                .ForMember(i => i.TenantId, options => options.MapFrom(i => i.TenantId.Value))
                .ForMember(i => i.LeasingAgreementId, options => options.MapFrom(i => i.LeasingAgreementId.Value));
        }
    }
}
