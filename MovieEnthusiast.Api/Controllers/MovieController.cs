using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Application.Common.Requests;
using MovieEnthusiast.Application.Movies.Queries;

namespace MovieEnthusiast.Api.Controllers;

public class MovieController : ApiControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public MovieController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Get a list with all "<see cref="MovieDto"/>" movies.
    /// </summary>
    /// /// <response code="200">Returns a list of movies.</response>
    [HttpGet]
    public async Task<ActionResult<PaginatedList<MovieDto>>> Get(
        [FromQuery] GetMoviesRequest request, CancellationToken cancellationToken)
    {
        var query = _mapper.Map<GetMoviesQuery>(request);
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}