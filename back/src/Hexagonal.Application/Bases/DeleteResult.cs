﻿using Hexagonal.Domain.Bases;
using Hexagonal.Domain.Enums;

namespace Hexagonal.Application.Bases;

public class DeleteResult<TEntity> : SingleResult<TEntity>
    where TEntity : Entity
{
    public DeleteResult()
    {
        Code = (int) EnumResponse.Ok;
        Success = true;
        Message = "";
    }

    public DeleteResult(bool success, string? message)
    {
        Code = success ? (int) EnumResponse.Ok : (int) EnumResponse.NotFound;
        Success = success;
        Message = message;
    }
}