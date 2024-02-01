using System.ComponentModel.DataAnnotations;
using Hexagonal.API.Modules.Common;
using Hexagonal.API.Modules.Common.FeatureFlags;
using Hexagonal.Application.Bases;
using Hexagonal.Application.Components.BookComponent.Commands;
using Hexagonal.Application.Components.BookComponent.Contracts;
using Hexagonal.Application.Components.BookComponent.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Hexagonal.API.Controllers;

// [Authorize]
[FeatureGate(CustomFeature.Book)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class BookController(
    IBookCommand bookCommand,
    IBookQuery bookQuery,
    ILogger<BookController> logger)
    : ControllerBase
{
    private readonly ILogger<BookController> _logger = logger;

    [HttpGet("get-all")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await bookQuery.GetAll().ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }


    [HttpGet("get-by-projection")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetByProjection(string propName, string value)
    {
        try
        {
            var result = await bookQuery.GetByProjection(propName, value).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    /// <summary>
    ///     Get an book details.
    /// </summary>
    /// <param name="bookId"></param>
    [HttpGet("get-by-id/{bookId:int}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
    public async Task<IActionResult> GetById([FromRoute] [Required] int bookId)
    {
        try
        {
            var result = await bookQuery.GetById(bookId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpPost("create")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
    public async Task<IActionResult> Create([FromBody] [Required] BookCreateDto dto)
    {
        try
        {
            var result = await bookCommand.Create(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpPut("edit")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
    public async Task<IActionResult> Edit([FromBody] [Required] BookEditDto dto)
    {
        try
        {
            var result = await bookCommand.Edit(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpDelete("delete/{bookId:int}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
    public async Task<IActionResult> Delete([FromRoute] [Required] int bookId)
    {
        try
        {
            var result = await bookCommand.Delete(bookId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}