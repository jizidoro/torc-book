using Hexagonal.Domain;

namespace Hexagonal.Application.Components.BookComponent.Core.Validations;

public class BookDeleteValidation : IBookDeleteValidation
{
    public bool Execute(Book entity)
    {
        return true;
    }
}