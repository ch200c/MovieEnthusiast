using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieEnthusiast.Application.Commands;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Application.Queries;

namespace MovieEnthusiast.Api.Controllers;

public class MovieController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("api/movies")]
    [HttpGet]
    [ProducesResponseType<IEnumerable<MovieDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMovies(CancellationToken cancellationToken)
    {
        var query = new GetMoviesQuery();
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
    
    [Route("api/movies")]
    [HttpPost]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddMovie(MovieDto movie, CancellationToken cancellationToken)
    {
        var command = new AddMovieCommand(movie);
        var identifier = await _mediator.Send(command, cancellationToken);

        return Ok(identifier);
    }
}