using AutoMapper;
using Hexagonal.Application.Paginations;

namespace Hexagonal.Application.Mappers;

public static class AutoMapperConfig
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new DomainToDtoMappingProfile());
            cfg.AddProfile(new DtoToDomainMappingProfile());
            cfg.AddProfile(new PaginationProfile());
        });
    }
}