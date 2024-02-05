using MediatR;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Application.Extensions.Entities;

namespace MovieEnthusiast.Application.Queries;

public class GetMoviesQueryHandler(IMovieRepository movieRepository) : IRequestHandler<GetMoviesQuery, IEnumerable<MovieDto>>
{
    private readonly IMovieRepository _movieRepository = movieRepository;

    public async Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetMovies(cancellationToken);

        return movies.ToApplication();
    }
}
