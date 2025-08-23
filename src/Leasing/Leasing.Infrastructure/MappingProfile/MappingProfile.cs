using AutoMapper;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Tenant
            CreateMap<Tenant, TenantResponse>()
                .ForMember(t => t.Id, options => options.MapFrom(t => t.Id.Value));

            // Mapping for Apartment
            CreateMap<Apartment, ApartmentResponse>()
                .ForMember(a => a.Id, options => options.MapFrom(a => a.Id.Value));

            // Mapping for Apartment Leasing History
            CreateMap<LeasingRecord, ApartmentLeasingRecordResponse>()
                .ForMember(lr => lr.Id, options => options.MapFrom(lr => lr.Id.Value));
            CreateMap<Tenant, ApartmentLesseeResponse>()
                .ForMember(t => t.Id, options => options.MapFrom(t => t.Id.Value));

            // Mapping for Tenant Leasing History
            CreateMap<LeasingRecord, TenantLeasingRecordResponse>()
                .ForMember(lr => lr.Id, options => options.MapFrom(lr => lr.Id.Value));
            CreateMap<Apartment, ApartmentLeasedResponse>()
                .ForMember(a => a.Id, options => options.MapFrom(a => a.Id.Value));

            // Mapping for Owner
            CreateMap<Owner, OwnerResponse>()
                .ForMember(o => o.Id, options => options.MapFrom(o => o.Id.Value));
        }
    }
}
