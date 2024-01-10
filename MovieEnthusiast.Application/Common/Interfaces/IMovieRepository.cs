using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Application.Common.Interfaces;

public interface IMovieRepository
{
    Task<IList<Movie>> GetMovies(CancellationToken cancellationToken);
}
