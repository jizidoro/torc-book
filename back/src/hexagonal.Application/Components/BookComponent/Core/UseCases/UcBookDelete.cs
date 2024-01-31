using hexagonal.Application.Bases;
using hexagonal.Application.Bases.Interfaces;
using hexagonal.Application.Components.BookComponent.Core.Validations;
using hexagonal.Data.Bases;
using hexagonal.Domain;
using hexagonal.Domain.Bases;

namespace hexagonal.Application.Components.BookComponent.Core.UseCases;

public class UcBookDelete(IBookDeleteValidation bookDeleteValidation, IRedisRepository<Book> redisRepository)
    : UseCase, IUcBookDelete
{
    public async Task<ISingleResult<Entity>> Execute(int id)
    {
        var entity = new Book {Id = id};

        var savedRecord = await redisRepository.GetById(entity.Id).ConfigureAwait(false);

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
        redisRepository.Remove(bookId);

        return new DeleteResult<Entity>(true,
            "");
    }
}