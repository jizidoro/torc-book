using hexagonal.Application.Bases.Interfaces;
using hexagonal.Application.Components.BookComponent.Contracts;
using hexagonal.Application.Paginations;

namespace hexagonal.Application.Components.BookComponent.Queries;

public interface IBookQuery
{
    Task<IPageResultDto<BookDto>> GetAll(PaginationQuery? paginationQuery = null);
    Task<ISingleResultDto<BookDto>> GetById(int id);
    Task<IPageResultDto<BookDto>> GetByProjection(string propName, string value);
}