﻿using AutoMapper;
using hexagonal.Application.Components.BookComponent.Contracts;
using hexagonal.Domain;

namespace hexagonal.Application.Mappers;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<BookDto, Book>();
        CreateMap<BookCreateDto, Book>();
        CreateMap<BookEditDto, Book>();
    }
}