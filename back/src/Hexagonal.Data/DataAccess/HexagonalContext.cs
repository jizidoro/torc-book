using Hexagonal.Data.Mappings;
using Hexagonal.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Data.DataAccess;

public class HexagonalContext : DbContext
{
    public HexagonalContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BookConfiguration());
    }
}