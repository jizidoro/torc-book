using Hexagonal.Application.Bases;

namespace Hexagonal.Application.Components.BookComponent.Contracts;

public class BookDto : EntityDto
{
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? TotalCopies { get; set; }
    public string? CopiesInUse { get; set; }
    public string? Type { get; set; }
    public string? Isbn { get; set; }
    public string? Category { get; set; }
}