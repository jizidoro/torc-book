using AutoMapper;
using Hexagonal.Application.Components.BookComponent.Contracts;
using Hexagonal.Domain;

namespace Hexagonal.Application.Mappers;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Book, BookDto>();
    }
}