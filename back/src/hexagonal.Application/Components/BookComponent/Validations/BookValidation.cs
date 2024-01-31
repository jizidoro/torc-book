using hexagonal.Application.Bases;
using hexagonal.Application.Components.BookComponent.Contracts;

namespace hexagonal.Application.Components.BookComponent.Validations;

public class BookValidation<TDto> : DtoValidation<TDto>
    where TDto : BookDto
{
}