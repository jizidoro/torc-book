using hexagonal.Application.Bases;
using hexagonal.Application.Bases.Interfaces;
using hexagonal.Application.Components.BookComponent.Core.Validations;
using hexagonal.Data.Bases;
using hexagonal.Domain;
using hexagonal.Domain.Bases;

namespace hexagonal.Application.Components.BookComponent.Core.UseCases;

public class UcBookCreate(IBookCreateValidation bookCreateValidation, IRedisRepository<Book> redisRepository)
    : UseCase, IUcBookCreate
{
    public async Task<ISingleResult<Entity>> Execute(Book newRecord)
    {
        var isValid = ValidateEntity(newRecord);
        if (!isValid.Success)
        {
            return isValid;
        }

        var validate = bookCreateValidation.Execute(newRecord);
        if (!validate)
        {
            return new ErrorResult<Entity>();
        }

        await redisRepository.Add(newRecord).ConfigureAwait(false);

        return new CreateResult<Entity>(true,
            "");
    }
}