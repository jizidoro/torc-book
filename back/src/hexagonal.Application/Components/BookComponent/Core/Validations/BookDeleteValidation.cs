﻿using hexagonal.Domain;

namespace hexagonal.Application.Components.BookComponent.Core.Validations;

public class BookDeleteValidation : IBookDeleteValidation
{
    public bool Execute(Book entity)
    {
        return true;
    }
}