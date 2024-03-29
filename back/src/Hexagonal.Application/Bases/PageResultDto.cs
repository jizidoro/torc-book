﻿using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Application.Paginations;
using Hexagonal.Domain.Enums;

namespace Hexagonal.Application.Bases;

public class PageResultDto<T> : ResultDto, IPageResultDto<T>
    where T : Dto
{
    public PageResultDto(List<T>? data)
    {
        Data = data;
        Code = data == null ? (int) EnumResponse.NotFound : (int) EnumResponse.Ok;
        Success = data != null;
        Message = data == null
            ? ""
            : string.Empty;
    }

    public PageResultDto(string message)
    {
        Data = null;
        Code = (int) EnumResponse.NotFound;
        Success = false;
        Message = message;
    }

    public PageResultDto(PaginationFilter pagination, List<T>? data)
    {
        Data = data;
        PageNumber = pagination.PageNumber >= 1 ? pagination.PageNumber : null;
        PageSize = pagination.PageNumber >= 1 ? pagination.PageSize : null;
        NextPage = pagination.PageNumber + 1;
        PreviousPage = pagination.PageNumber > 1 ? pagination.PageNumber - 1 : null;
        Code = (int) EnumResponse.Ok;
        Success = true;
        Message = data == null
            ? ""
            : string.Empty;
    }

    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int? NextPage { get; set; }
    public int? PreviousPage { get; set; }
    public IList<T>? Data { get; set; }
}