using Hexagonal.Domain;

namespace Hexagonal.Application.Components.BookComponent.Core.Validations;

public class BookCreateValidation : IBookCreateValidation
{
    public bool Execute(Book entity)
    {
        return true;
    }
}