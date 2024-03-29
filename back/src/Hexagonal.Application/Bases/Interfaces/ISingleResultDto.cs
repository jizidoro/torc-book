﻿namespace Hexagonal.Application.Bases.Interfaces;

public interface ISingleResultDto<out TDto> : IResultDto
    where TDto : Dto
{
    TDto? Data { get; }
}