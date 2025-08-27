using AutoMapper;
using Ownership.Application.Response;
using Ownership.Domain.Entities;

namespace Ownership.Infrastructure.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Owner
            CreateMap<Owner, OwnerResponse>()
                .ForMember(o => o.Id, options => options.MapFrom(o => o.Id.Value));
        }
    }
}
