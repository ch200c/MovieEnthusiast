using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Infrastructure.Persistence.Repositories;

public class MovieRepository : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        await Task.Run(() =>
        {
        });

        var movie = new Movie()
        {
            Id = 1,
            Title = "Shrek 2",
            ReleasedOn = DateTime.Now
        };

        List<Movie> movies = new()
        {
            movie
        };

        return movies;
    }
}

