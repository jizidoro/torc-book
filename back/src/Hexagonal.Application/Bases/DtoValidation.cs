using FluentValidation;

namespace Hexagonal.Application.Bases;

public class DtoValidation<TDto> : AbstractValidator<TDto>
    where TDto : EntityDto
{
}