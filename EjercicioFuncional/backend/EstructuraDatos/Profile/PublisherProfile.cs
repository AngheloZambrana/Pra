using DTOs;
using DTOs.WithoutIDs;
using Entities;

namespace Docker.Profile;

public class PublisherProfile: AutoMapper.Profile
{
    public PublisherProfile()
    {
        CreateMap<Publisher, PublisherDTO>().ReverseMap();
        CreateMap<(PostPublisher post, Guid id), Publisher>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.post));
    }
}
