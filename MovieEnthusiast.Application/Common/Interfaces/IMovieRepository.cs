using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Application.Common.Interfaces;

public interface IMovieRepository
{
    Task<PaginatedEntity<Movie>> GetMovies(Pagination pagination, CancellationToken cancellationToken);
}
