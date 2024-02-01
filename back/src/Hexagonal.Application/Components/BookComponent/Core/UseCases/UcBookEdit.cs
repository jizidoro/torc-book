using Hexagonal.Application.Bases;
using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Application.Components.BookComponent.Core.Validations;
using Hexagonal.Data.Bases;
using Hexagonal.Domain;
using Hexagonal.Domain.Bases;

namespace Hexagonal.Application.Components.BookComponent.Core.UseCases;

public class UcBookEdit(IBookEditValidation bookEditValidation, IRedisRepository<Book> redisRepository)
    : UseCase, IUcBookEdit
{
    public async Task<ISingleResult<Entity>> Execute(Book newRecord)
    {
        var isValid = ValidateEntity(newRecord);
        if (!isValid.Success)
        {
            return isValid;
        }

        var savedRecord = await redisRepository.GetById(newRecord.Id).ConfigureAwait(false);

        if (savedRecord is null)
        {
            return new ErrorResult<Entity>();
        }

        var validate = bookEditValidation.Execute(newRecord, savedRecord);
        if (!validate)
        {
            return new ErrorResult<Entity>();
        }

        var obj = savedRecord;
        HydrateValues(obj, newRecord);

        redisRepository.Update(obj);

        return new EditResult<Entity>(true,
            "");
    }

    private static void HydrateValues(Book target, Book source)
    {
        target.Title = source.Title;
        target.FirstName = source.FirstName;
        target.Category = source.Category;
        target.TotalCopies = source.TotalCopies;
        target.CopiesInUse = source.CopiesInUse;
        target.Type = source.Type;
        target.Isbn = source.Isbn;
        target.Category = source.Category;
    }
}