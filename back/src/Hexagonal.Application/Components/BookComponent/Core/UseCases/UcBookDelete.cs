using Hexagonal.Application.Bases;
using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Application.Components.BookComponent.Core.Validations;
using Hexagonal.Data;
using Hexagonal.Data.Bases;
using Hexagonal.Domain;
using Hexagonal.Domain.Bases;

namespace Hexagonal.Application.Components.BookComponent.Core.UseCases;

public class UcBookDelete(IBookDeleteValidation bookDeleteValidation, IBookRepository repository)
    : UseCase, IUcBookDelete
{
    public async Task<ISingleResult<Entity>> Execute(int id)
    {
        var entity = new Book {Id = id};

        var savedRecord = await repository.GetById(entity.Id).ConfigureAwait(false);

        if (savedRecord is null)
        {
            return new ErrorResult<Entity>();
        }

        var validate = bookDeleteValidation.Execute(savedRecord);
        if (!validate)
        {
            return new ErrorResult<Entity>(false, "Livro esta ativo");
        }

        var bookId = savedRecord.Id;
        repository.Remove(bookId);

        return new DeleteResult<Entity>(true,
            "");
    }
}