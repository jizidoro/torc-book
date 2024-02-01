using Hexagonal.Domain;

namespace Hexagonal.Application;

public interface IBookService
{
    Task<IQueryable<Book>> GetAllBooksAsync();
    Task<Book?> GetBookAsync(int id);
    Task<Book> AddBookAsync(Book book);
    Task<Book?> UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
}