using System.ComponentModel.DataAnnotations.Schema;
using hexagonal.Domain.Bases;

namespace hexagonal.Domain;

[Table("book_book")]
public class Book : Entity
{
    [Column("title", TypeName = "varchar")]
    public string? Title { get; set; }

    [Column("first_name", TypeName = "varchar")]
    public string? FirstName { get; set; }

    [Column("last_name", TypeName = "varchar")]
    public string? LastName { get; set; }

    [Column("total_copies", TypeName = "varchar")]
    public string? TotalCopies { get; set; }

    [Column("copies_in_use", TypeName = "varchar")]
    public string? CopiesInUse { get; set; }

    [Column("type", TypeName = "varchar")] public string? Type { get; set; }

    [Column("isbn", TypeName = "varchar")] public string? Isbn { get; set; }

    [Column("category", TypeName = "varchar")]
    public string? Category { get; set; }
}