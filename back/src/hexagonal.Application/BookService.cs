using hexagonal.Data;
using hexagonal.Domain;

namespace hexagonal.Application;

public class BookService(IBookRepository repository) : IBookService
{
    public async Task<IQueryable<Book>> GetAllBooksAsync()
    {
        return repository.GetAll();
    }

    public async Task<Book?> GetBookAsync(int id)
    {
        return await repository.GetById(id);
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        await repository.BeginTransactionAsync().ConfigureAwait(false);
        await repository.Add(book).ConfigureAwait(false);
        await repository.CommitTransactionAsync().ConfigureAwait(false);
        return book;
    }

    public async Task<Book?> UpdateBookAsync(Book book)
    {
        var existingBook = await repository.GetById(book.Id);
        if (existingBook != null)
        {
            await repository.BeginTransactionAsync().ConfigureAwait(false);
            repository.Update(existingBook);
            await repository.CommitTransactionAsync().ConfigureAwait(false);
        }

        return existingBook;
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await repository.GetById(id);
        if (book != null)
        {
            await repository.BeginTransactionAsync().ConfigureAwait(false);
            repository.Remove(book.Id);
            await repository.CommitTransactionAsync().ConfigureAwait(false);
        }
    }
}