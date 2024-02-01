using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Application.Components.BookComponent.Contracts;
using Hexagonal.Application.Paginations;

namespace Hexagonal.Application.Components.BookComponent.Queries;

public interface IBookQuery
{
    Task<IPageResultDto<BookDto>> GetAll(PaginationQuery? paginationQuery = null);
    Task<ISingleResultDto<BookDto>> GetById(int id);
    Task<IPageResultDto<BookDto>> GetByProjection(string propName, string value);
}