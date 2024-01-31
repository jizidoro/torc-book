using hexagonal.Data.Bases;
using hexagonal.Data.DataAccess;
using hexagonal.Domain;

namespace hexagonal.Data;

public class BookRepository(HexagonalContext context) : Repository<Book>(context), IBookRepository
{
    private readonly HexagonalContext _context = context ??
                                                 throw new ArgumentNullException(nameof(context));
}