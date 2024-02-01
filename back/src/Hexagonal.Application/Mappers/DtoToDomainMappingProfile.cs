using AutoMapper;
using Hexagonal.Application.Components.BookComponent.Contracts;
using Hexagonal.Domain;

namespace Hexagonal.Application.Mappers;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<BookDto, Book>();
        CreateMap<BookCreateDto, Book>();
        CreateMap<BookEditDto, Book>();
    }
}