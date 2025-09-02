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

                // The mapping for the list of line items will work automatically
                // because we defined the InvoiceLineItem -> InvoiceLineItemResponse map above.
                .ForMember(dest => dest.LineItems, opt => opt.MapFrom(src => src.LineItems))

                // Flatten the Money objects
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal.Amount))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount.Amount))
                .ForMember(dest => dest.AmountPaid, opt => opt.MapFrom(src => src.AmountPaid.Amount))
                .ForMember(dest => dest.AmountDue, opt => opt.MapFrom(src => src.AmountDue.Amount))

                // Assume all money is in the same currency for the invoice total for simplicity
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.TotalAmount.Currency));
        }
    }
}
