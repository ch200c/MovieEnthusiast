using MediatR;
using MovieEnthusiast.Application.Common.Models;

namespace MovieEnthusiast.Application.Queries;

public class GetMoviesQuery : IRequest<IEnumerable<MovieDto>>
{
}
