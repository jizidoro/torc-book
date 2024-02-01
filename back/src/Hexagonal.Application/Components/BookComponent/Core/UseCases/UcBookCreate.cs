using Hexagonal.Application.Bases;
using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Application.Components.BookComponent.Core.Validations;
using Hexagonal.Data;
using Hexagonal.Data.Bases;
using Hexagonal.Domain;
using Hexagonal.Domain.Bases;

namespace Hexagonal.Application.Components.BookComponent.Core.UseCases;

public class UcBookCreate(IBookCreateValidation bookCreateValidation, IBookRepository repository)
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

        await repository.Add(newRecord).ConfigureAwait(false);

        return new CreateResult<Entity>(true,
            "");
    }
}