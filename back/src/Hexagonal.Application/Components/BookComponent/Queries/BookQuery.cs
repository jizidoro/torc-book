using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hexagonal.Application.Bases;
using Hexagonal.Application.Bases.Interfaces;
using Hexagonal.Application.Components.BookComponent.Contracts;
using Hexagonal.Application.Paginations;
using Hexagonal.Data;
using Hexagonal.Domain;

namespace Hexagonal.Application.Components.BookComponent.Queries;

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

    public IPageResultDto<BookDto> GetByProjection(PaginationSearchQuery paginationSearchQuery)
    {
        var expression = ExpressionBuilder.BuildContainsExpression<Book>(paginationSearchQuery.PropName, paginationSearchQuery.Value);
        var entity = repository.GetByProjection(expression);

        if (!entity.Any())
        {
            return new PageResultDto<BookDto>("error the projection don`t generate any results" + expression.Body.ToString());
        }

        var skip = (paginationSearchQuery.PageNumber - 1) * paginationSearchQuery.PageSize;

        var list = entity
            .ProjectTo<BookDto>(mapper.ConfigurationProvider)
            .Skip(skip)
            .Take(paginationSearchQuery.PageSize)
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