using DTOs;
using DTOs.WithoutIDs;
using Entities;

namespace Profile;

public class AuthorProfile: AutoMapper.Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorDTO>().ReverseMap(); 
        CreateMap<(PostAuthor post, Guid id), Author>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.post.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.post.Surname))
            .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.post.Nationality)).ReverseMap();
    }
}
