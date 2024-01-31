using AutoMapper;
using AutoMapper.QueryableExtensions;
using hexagonal.Application.Bases;
using hexagonal.Application.Bases.Interfaces;
using hexagonal.Application.Components.BookComponent.Contracts;
using hexagonal.Application.Paginations;
using hexagonal.Data;
using System.Linq.Expressions;
using hexagonal.Domain;

namespace hexagonal.Application.Components.BookComponent.Queries;

public class BookQuery(
    IBookRepository repository,
    IMapper mapper)
    : IBookQuery
{
    public async Task<IPageResultDto<BookDto>> GetAll(
        PaginationQuery? paginationQuery = null)
    {
        var paginationFilter = mapper.Map<PaginationQuery?, PaginationFilter?>(paginationQuery);
        List<BookDto> list;
        if (paginationFilter == null)
        {
            list = await Task.Run(() => repository.GetAllAsNoTracking()
                .ProjectTo<BookDto>(mapper.ConfigurationProvider)
                .ToList());

            return new PageResultDto<BookDto>(list);
        }

        var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

        list = await Task.Run(() => repository.GetAllAsNoTracking().Skip(skip)
            .Take(paginationFilter.PageSize)
            .ProjectTo<BookDto>(mapper.ConfigurationProvider)
            .ToList());

        return new PageResultDto<BookDto>(paginationFilter, list);
    }

    public async Task<IPageResultDto<BookDto>> GetByProjection(string propName, string value)
    {
        Expression<Func<Book, bool>> expression = ExpressionBuilder.BuildContainsExpression<Book>(propName, value);
        var entity = repository.GetByProjection(expression);
        List<BookDto> list = entity
            .ProjectTo<BookDto>(mapper.ConfigurationProvider)
            .ToList();

        return new PageResultDto<BookDto>(list);
    }

    public async Task<ISingleResultDto<BookDto>> GetById(int id)
    {
        var entity = await repository.GetById(id);
        var dto = mapper.Map<BookDto>(entity);
        return new SingleResultDto<BookDto>(dto);
    }
}