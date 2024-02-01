using AutoMapper;
using Hexagonal.Application.Bases;
using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Application.Components.BookComponent.Contracts;
using Hexagonal.Application.Components.BookComponent.Core;
using Hexagonal.Application.Components.BookComponent.Validations;
using Hexagonal.Domain;

namespace Hexagonal.Application.Components.BookComponent.Commands;

public class BookCommand(
    IUcBookDelete deleteBook,
    IUcBookCreate createBook,
    IUcBookEdit editBook,
    IMapper mapper)
    : IBookCommand
{
    public async Task<ISingleResultDto<EntityDto>> Create(BookCreateDto dto)
    {
        var validator = new BookCreateValidation();
        var validationResult = await validator.ValidateAsync(dto);

        if (!validationResult.IsValid)
        {
            return new SingleResultDto<EntityDto>(validationResult);
        }

        var mappedObject = mapper.Map<Book>(dto);
        var result = await createBook.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }

    public async Task<ISingleResultDto<EntityDto>> Edit(BookEditDto dto)
    {
        var validator = new BookEditValidation();
        var validationResult = await validator.ValidateAsync(dto);

        if (!validationResult.IsValid)
        {
            return new SingleResultDto<EntityDto>(validationResult);
        }

        var mappedObject = mapper.Map<Book>(dto);
        var result = await editBook.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }

    public async Task<ISingleResultDto<EntityDto>> Delete(int id)
    {
        var result = await deleteBook.Execute(id).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}