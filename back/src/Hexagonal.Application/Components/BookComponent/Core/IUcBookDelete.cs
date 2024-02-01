using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Domain.Bases;

namespace Hexagonal.Application.Components.BookComponent.Core;

public interface IUcBookDelete
{
    Task<ISingleResult<Entity>> Execute(int id);
}