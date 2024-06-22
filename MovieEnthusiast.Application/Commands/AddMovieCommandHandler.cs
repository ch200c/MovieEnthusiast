using MediatR;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Application.Extensions.Entities;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Application.Commands;

public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, int>
{
    private readonly IGenericRepository<Movie> _movieRepository;

    public AddMovieCommandHandler(IGenericRepository<Movie> movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public async Task<int> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = request.movie.ToDomain();
        var id = await _movieRepository.Add(movie, cancellationToken);

        return id;
    }
}