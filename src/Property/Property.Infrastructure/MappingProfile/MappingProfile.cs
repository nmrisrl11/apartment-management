using AutoMapper;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Apartment Unit
            CreateMap<ApartmentUnit, ApartmentUnitResponse>()
                .ForMember(au => au.Id, options => options.MapFrom(au => au.Id.Value))
                .ForMember(au => au.OwnerId, options => options.MapFrom(au => au.Id.Value))
                .ForMember(au => au.Owner, options => options.MapFrom(au => au.Owner));

            // Mapping for Owner
            CreateMap<Owner, OwnerResponse>()
                .ForMember(o => o.Id, options => options.MapFrom(o => o.Id.Value));
        }
    }
}
