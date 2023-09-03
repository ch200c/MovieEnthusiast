using AutoMapper;
using MediatR;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Application.Common.Models;

namespace MovieEnthusiast.Application.Movies.Queries;

public class GetMoviesWithPaginationQueryHandler
    : IRequestHandler<GetMoviesQuery, PaginatedList<MovieDto>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetMoviesWithPaginationQueryHandler(
        IMovieRepository movieRepository,
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;

    }
    public async Task<PaginatedList<MovieDto>> Handle(
        GetMoviesQuery request,
        CancellationToken cancellationToken)
    {
        var paginatedMovies = await _movieRepository
            .GetMovies(request.AsPagination(), cancellationToken);

        var result = _mapper.Map<IReadOnlyCollection<MovieDto>>(paginatedMovies.Items);

        var paginatedResult = new PaginatedList<MovieDto>(
            result,
            request.PageNumber,
            request.PageSize,
            paginatedMovies.TotalItemCount);

        return paginatedResult;
    }
}
