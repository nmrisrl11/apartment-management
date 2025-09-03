using AutoMapper;
using Billing.Application.Response;
using Billing.Domain.Entities;

namespace Billing.Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Invoice Line Item
            CreateMap<InvoiceLineItem, InvoiceLineItemResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice.Amount));

            // Mapping for Invoice
            CreateMap<Invoice, InvoiceResponse>()
                .ForMember(i => i.Id, options => options.MapFrom(i => i.Id.Value))
                .ForMember(i => i.TenantId, options => options.MapFrom(i => i.TenantId.Value))
                .ForMember(i => i.LeasingAgreementId, options => options.MapFrom(i => i.LeasingAgreementId.Value))

                // Flatten the DateRange object
                .ForMember(dest => dest.ServicePeriodStartDate, opt => opt.MapFrom(src => src.ServicePeriod.StartDate))
                .ForMember(dest => dest.ServicePeriodEndDate, opt => opt.MapFrom(src => src.ServicePeriod.EndDate))
                
                .ForMember(dest => dest.LineItems, opt => opt.MapFrom(src => src.LineItems))

                // Flatten the Money objects
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src =>
                    src.LineItems.Sum(li => li.Quantity * li.UnitPrice.Amount)
                ))
                
                // TotalAmount == SubTotal by default, can add here taxes if needed
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src =>
                    src.LineItems.Sum(li => li.Quantity * li.UnitPrice.Amount)
                ))

                .ForMember(dest => dest.AmountPaid, opt => opt.MapFrom(src => src.AmountPaid.Amount))

                // AmountDue is TotalAmount - AmountPaid
                .ForMember(dest => dest.AmountDue, opt => opt.MapFrom(src =>
                    src.LineItems.Sum(li => li.Quantity * li.UnitPrice.Amount) - src.AmountPaid.Amount
                ))
                 
                // Currency exists even the Totals are Zero
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src =>
                    src.LineItems.Select(li => li.UnitPrice.Currency).FirstOrDefault() ?? "PHP"
                ));

            // Mapping for Tenant
            CreateMap<Tenant, TenantResponse>()
                .ForMember(l => l.Id, options => options.MapFrom(l => l.Id.Value));

            // Mapping for Leasing Agrement
            CreateMap<LeasingAgreement, LeasingAgreementResponse>()
                .ForMember(l => l.Id, options => options.MapFrom(l => l.Id.Value));

            // Mapping for Payment
            CreateMap<Payment, PaymentResponse>()
                .ForMember(p => p.Id, options => options.MapFrom(p => p.Id.Value))
                .ForMember(p => p.InvoiceId, options => options.MapFrom(p => p.InvoiceId.Value))
                .ForMember(dest => dest.Amount, options => options.MapFrom(src => src.Amount.Amount))
                .ForMember(dest => dest.Currency, options => options.MapFrom(src => src.Amount.Currency));
        }
    }
}
