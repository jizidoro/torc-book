using AutoMapper;
using hexagonal.Application.Components.BookComponent.Contracts;
using hexagonal.Domain;

namespace hexagonal.Application.Mappers;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Book, BookDto>();
    }
}