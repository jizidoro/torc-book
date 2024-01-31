using hexagonal.Data.Mappings;
using hexagonal.Domain;
using Microsoft.EntityFrameworkCore;

namespace hexagonal.Data.DataAccess;

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