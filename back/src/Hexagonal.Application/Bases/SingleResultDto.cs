﻿using FluentValidation.Results;
using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Domain.Bases;
using Hexagonal.Domain.Enums;
using ValidationFailure = Microsoft.IdentityModel.Tokens.ValidationFailure;

namespace Hexagonal.Application.Bases;

public class SingleResultDto<TDto> : ResultDto, ISingleResultDto<TDto>
    where TDto : Dto
{
    private ValidationResult _validationResult;

    public SingleResultDto(TDto? data)
    {
        Code = data == null ? (int) EnumResponse.NotFound : (int) EnumResponse.Ok;
        Success = data != null;
        Message = data == null
            ? ""
            : string.Empty;
        Data = data;
    }

    public SingleResultDto(Exception ex)
    {
        Code = (int) EnumResponse.InternalServerError;
        Success = false;
        Message = ex.Message;
        ExceptionMessage = ex.Message;
    }

    public SingleResultDto(IResult result)
    {
        Code = result.Code;
        Success = result.Success;
        Message = result.Message;

        if (result is SingleResult<Entity> entityResult)
        {
            Messages = entityResult.Messages?.ToList();
        }
    }

    public SingleResultDto(List<ValidationFailure> failures)
    {
        Code = (int) EnumResponse.ErrorBusinessValidation;
        Success = false;
    }

    public SingleResultDto(ValidationResult validationResult)
    {
        Code = 400;
        Success = false;
        ValidationResult = validationResult;
    }

    public ValidationResult? ValidationResult { get; }

    public TDto? Data { get; }
}