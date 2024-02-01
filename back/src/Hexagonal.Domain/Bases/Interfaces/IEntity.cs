namespace Hexagonal.Domain.Bases.Interfaces;

public interface IEntity
{
    int Id { get; }
    int Key { get; }
    string Value { get; }
}