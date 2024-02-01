using Hexagonal.Data.Bases;
using Hexagonal.Data.DataAccess;
using Hexagonal.Domain;

namespace Hexagonal.Data;

public class BookRepository(HexagonalContext context) : Repository<Book>(context), IBookRepository
{
    private readonly HexagonalContext _context = context ??
                                                 throw new ArgumentNullException(nameof(context));
}