using Hexagonal.Application.Bases.Interfaces;

namespace Hexagonal.Application.Bases;

public class EntityDto : Dto, IEntityDto
{
    public int Id { get; set; }
}