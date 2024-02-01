using Hexagonal.Domain.Bases;
using Hexagonal.Domain.Enums;

namespace Hexagonal.Application.Bases;

public class ErrorResult<TEntity> : SingleResult<TEntity>
    where TEntity : Entity
{
    public ErrorResult()
    {
        Code = (int) EnumResponse.ErrorBusinessValidation;
        Success = true;
        Message = "";
    }

    public ErrorResult(bool success, string? message)
    {
        Code = (int) EnumResponse.ErrorBusinessValidation;
        Success = success;
        Message = message;
    }
}