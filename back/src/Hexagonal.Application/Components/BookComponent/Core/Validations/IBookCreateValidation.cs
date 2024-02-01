using Hexagonal.Domain;

namespace Hexagonal.Application.Components.BookComponent.Core.Validations;

public interface IBookCreateValidation
{
    bool Execute(Book entity);
}