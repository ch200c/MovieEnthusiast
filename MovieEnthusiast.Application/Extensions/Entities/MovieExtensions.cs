using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Application.Extensions.Entities;

public static class MovieExtensions
{
    public static IEnumerable<MovieDto> ToApplication(this IEnumerable<Movie> movies)
    {
        return movies.Select(x => new MovieDto(x.Id, x.Title));
    }
}