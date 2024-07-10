using MovieEnthusiast.Domain.Data;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Application.Common.Interfaces;

public interface IMovieRepository : IRepository
{
    Task<IEnumerable<Movie>> GetMovies(CancellationToken cancellationToken);
}
