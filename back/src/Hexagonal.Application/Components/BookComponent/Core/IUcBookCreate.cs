using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Domain;
using Hexagonal.Domain.Bases;

namespace Hexagonal.Application.Components.BookComponent.Core;

public interface IUcBookCreate
{
    Task<ISingleResult<Entity>> Execute(Book newRecord);
}