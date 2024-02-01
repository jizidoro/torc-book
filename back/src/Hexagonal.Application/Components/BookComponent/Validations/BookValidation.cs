using Hexagonal.Application.Bases;
using Hexagonal.Application.Components.BookComponent.Contracts;

namespace Hexagonal.Application.Components.BookComponent.Validations;

public class BookValidation<TDto> : DtoValidation<TDto>
    where TDto : BookDto
{
}