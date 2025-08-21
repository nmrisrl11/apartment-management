using AutoMapper;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Apartment
            CreateMap<Apartment, ApartmentResponse>()
                .ForMember(a => a.Id, options => options.MapFrom(a => a.Id.Value));
        }
    }
}
