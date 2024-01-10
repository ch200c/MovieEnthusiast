using Microsoft.EntityFrameworkCore;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Domain.Entities;
using MovieEnthusiast.Infrastructure.Persistence;

namespace MovieEnthusiast.Infrastructure.Repositories;

public class MovieRepository(ApplicationDbContext context) : IMovieRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IList<Movie>> GetMovies(CancellationToken cancellationToken)
    {
        var movies = await _context.Movies.ToListAsync(cancellationToken);

        return movies;
    }
}
