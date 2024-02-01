using Hexagonal.Domain;

namespace Hexagonal.Application.Components.BookComponent.Core.Validations;

public interface IBookEditValidation
{
    bool Execute(Book newRecord, Book? savedRecord);
}