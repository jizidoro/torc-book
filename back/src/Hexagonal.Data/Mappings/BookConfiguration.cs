using Hexagonal.Data.Bases;
using Hexagonal.Data.Extensions;
using Hexagonal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hexagonal.Data.Mappings;

public class BookConfiguration : BaseMappingConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Id).HasColumnName("book_id").IsRequired();
        builder.HasKey(c => c.Id).HasName("pk_book_book");

        builder.InsertSeedData($"{SeedJsonBasePath}.book.json");
    }
}