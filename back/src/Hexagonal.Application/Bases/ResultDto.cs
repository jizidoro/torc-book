﻿using Hexagonal.Application.Bases.Interfaces;

namespace Hexagonal.Application.Bases;

public class ResultDto : IResultDto
{
    public string? ExceptionMessage { get; set; }
    public IList<string>? Messages { get; set; }
    public int Code { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; } = "";
}