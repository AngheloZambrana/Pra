using DTOs;
using DTOs.WithoutIDs;
using Entities;

namespace Docker.Profile;

public class LoanProfile: AutoMapper.Profile
{
    public LoanProfile()
    {
        CreateMap<Loan, LoanDTO>().ReverseMap();
        CreateMap<(PostLoan post, Guid id), Loan>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.BookId, opt => opt.MapFrom(stc => stc.post))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.LoanStart, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.LoanEnd, opt => opt.MapFrom(src => src.post)).ReverseMap();
    }
}
