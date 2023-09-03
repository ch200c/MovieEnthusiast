using Microsoft.EntityFrameworkCore;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Infrastructure.Persistence.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _context;

    public MovieRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedEntity<Movie>> GetMovies(
        Pagination pagination,
        CancellationToken cancellationToken)
    {
        var position = (pagination.PageNumber - 1) * pagination.PageSize;

        var movies = await _context.Movies
            .OrderBy(movie => movie.Id)
            .Skip(position)
            .Take(pagination.PageSize)
            .ToListAsync(cancellationToken);

        int? totalItemCount = null;
        if (pagination.ReturnTotalCount)
        {
            totalItemCount = await _context.Movies
            .CountAsync(cancellationToken);
        }

        var paginatedResult = new PaginatedEntity<Movie>
        {
            Items = movies,
            TotalItemCount = totalItemCount
        };

        return paginatedResult;
    }
}

