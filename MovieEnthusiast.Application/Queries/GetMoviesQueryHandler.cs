using MediatR;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Application.Extensions.Entities;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Application.Queries;

public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieDto>>
{
    private readonly IGenericRepository<Movie> _movieRepository;

    public GetMoviesQueryHandler(IGenericRepository<Movie> movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public async Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetAll(cancellationToken);

        return movies.ToApplication();
    }
}
