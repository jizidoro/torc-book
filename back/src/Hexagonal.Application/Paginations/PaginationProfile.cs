using AutoMapper;

namespace Hexagonal.Application.Paginations;

public class PaginationProfile : Profile
{
    public PaginationProfile()
    {
        CreateMap<PaginationQuery, PaginationFilter>();
    }
}