using Hexagonal.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hexagonal.Data.Bases;

public abstract class BaseMappingConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    protected const string SeedJsonBasePath = "Hexagonal.Data.SeedData";
    public abstract void Configure(EntityTypeBuilder<T> builder);
}