using DTOs;
using DTOs.WithoutIDs;
using Entities;

namespace Docker.Profile;

public class BookProfile: AutoMapper.Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDTO>().ReverseMap();
        CreateMap<(PostBook post, Guid id), Book>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.post.CreatedAt));
    }
}
