using Hexagonal.Domain;

namespace Hexagonal.Application.Components.BookComponent.Core.Validations;

public interface IBookDeleteValidation
{
    bool Execute(Book entity);
}