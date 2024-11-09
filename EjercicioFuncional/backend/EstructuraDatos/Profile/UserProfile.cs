using DTOs;
using DTOs.WithoutIDs;
using Entities;

namespace Docker.Profile;

public class UserProfile: AutoMapper.Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<(PostUser post, Guid id), User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.RegisterTime, opt => opt.MapFrom(src => src.post));


    }
}