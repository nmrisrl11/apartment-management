using AutoMapper;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Leasing Agreement
            CreateMap<LeasingAgreement, LeasingAgreementResponse>()
                .ForMember(la => la.Id, options => options.MapFrom(la => la.Id.Value))
                .ForMember(la => la.TenantId, options => options.MapFrom(la => la.TenantId.Value))
                .ForMember(la => la.LessorId, options => options.MapFrom(la => la.LessorId.Value))
                .ForMember(la => la.ApartmentId, options => options.MapFrom(la => la.ApartmentId.Value));

            // Mapping for Tenant
            CreateMap<Tenant, TenantResponse>()
                .ForMember(t => t.Id, options => options.MapFrom(t => t.Id.Value));

            // Mapping for Apartment
            CreateMap<Apartment, ApartmentResponse>()
                .ForMember(a => a.Id, options => options.MapFrom(a => a.Id.Value))
                .ForMember(a => a.LessorId, options => options.MapFrom(a => a.LessorId.Value))
                .ForMember(a => a.Lessor, options => options.MapFrom(a => a.Lessor));

            // Mapping for Apartment Leasing History
            CreateMap<LeasingRecord, ApartmentLeasingRecordResponse>()
                .ForMember(lr => lr.Id, options => options.MapFrom(lr => lr.Id.Value))
                .ForMember(lr => lr.Lessee, options => options.MapFrom(lr => lr.Tenant));
            CreateMap<Tenant, ApartmentLesseeResponse>()
                .ForMember(t => t.Id, options => options.MapFrom(t => t.Id.Value));

            // Mapping for Tenant Leasing History
            CreateMap<LeasingRecord, TenantLeasingRecordResponse>()
                .ForMember(lr => lr.Id, options => options.MapFrom(lr => lr.Id.Value));
            CreateMap<Apartment, ApartmentLeasedResponse>()
                .ForMember(a => a.Id, options => options.MapFrom(a => a.Id.Value))
                .ForMember(a => a.LessorId, options => options.MapFrom(a => a.LessorId.Value))
                .ForMember(a => a.Lessor, options => options.MapFrom(a => a.Lessor));

            // Mapping for Lessor
            CreateMap<Lessor, LessorResponse>()
                .ForMember(l => l.Id, options => options.MapFrom(l => l.Id.Value));
        }
    }
}
