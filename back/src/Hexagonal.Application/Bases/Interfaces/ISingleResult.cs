using Hexagonal.Domain.Bases.Interfaces;

namespace Hexagonal.Application.Bases.Interfaces;

public interface ISingleResult<TEntity> : IResult
    where TEntity : IEntity
{
    TEntity? Data { get; set; }
}