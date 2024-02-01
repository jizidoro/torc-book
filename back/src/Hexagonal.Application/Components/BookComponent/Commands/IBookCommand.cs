using Hexagonal.Application.Bases;
using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Application.Components.BookComponent.Contracts;

namespace Hexagonal.Application.Components.BookComponent.Commands;

public interface IBookCommand
{
    Task<ISingleResultDto<EntityDto>> Create(BookCreateDto dto);
    Task<ISingleResultDto<EntityDto>> Edit(BookEditDto dto);
    Task<ISingleResultDto<EntityDto>> Delete(int id);
}