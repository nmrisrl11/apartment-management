using AutoMapper;
using Tenancy.Application.Response;
using Tenancy.Domain.Entities;

namespace Tenancy.Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Tenant
            CreateMap<Tenant, TenantResponse>()
                .ForMember(t => t.Id, options => options.MapFrom(t => t.Id.Value));
        }
    }
}
