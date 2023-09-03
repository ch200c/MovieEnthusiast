using MovieEnthusiast.Application.Common.Models;

namespace MovieEnthusiast.Application.Movies.Queries;

public class GetMoviesQuery : PaginatedQuery<PaginatedList<MovieDto>>
{
}