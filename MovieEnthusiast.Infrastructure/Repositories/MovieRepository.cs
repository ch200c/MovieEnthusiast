using Microsoft.EntityFrameworkCore;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Domain.Data;
using MovieEnthusiast.Domain.Entities;
using MovieEnthusiast.Infrastructure.Persistence;

namespace MovieEnthusiast.Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public MovieRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetMovies(CancellationToken cancellationToken)
    {
        var movies = await _context.Movies.ToListAsync(cancellationToken);

        return movies;
    }
}
