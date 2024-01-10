using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Application.Queries;

namespace MovieEnthusiast.Api.Controllers;

public class MovieController(IMediator mediator) : ApiControllerBase
{
    private readonly IMediator _mediator = mediator;

    [Route("api/movies")]
    [HttpGet]
    [ProducesResponseType<IEnumerable<MovieDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMovies(CancellationToken cancellationToken)
    {
        var query = new GetMoviesQuery();
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}