namespace Hexagonal.Application.Paginations;

public class PaginationSearchQuery(int pageNumber, int pageSize, string propName, string value)
{
    public PaginationSearchQuery() : this(1, 50,"","")
    {
    }

    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public string PropName { get; set; } = propName;
    public string Value { get; set; } = value;
}