using MediatR;
using MovieEnthusiast.Application.Common.Models;

namespace MovieEnthusiast.Application.Commands;

public record AddMovieCommand(MovieDto movie) : IRequest<int>;
