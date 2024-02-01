using Hexagonal.Domain.Bases;
using Hexagonal.Domain.Enums;

namespace Hexagonal.Application.Bases;

public class EditResult<TEntity> : SingleResult<TEntity>
    where TEntity : Entity
{
    public EditResult()
    {
        Code = (int) EnumResponse.NoContent;
        Success = true;
        Message = "";
    }

    public EditResult(bool success, string? message)
    {
        Code = success ? (int) EnumResponse.NoContent : (int) EnumResponse.NotFound;
        Success = success;
        Message = message;
    }
}