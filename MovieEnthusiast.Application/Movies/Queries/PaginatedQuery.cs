using MediatR;
using MovieEnthusiast.Application.Common.Models;

namespace MovieEnthusiast.Application.Movies.Queries;

public class PaginatedQuery<T> : IRequest<T>
{
    public int PageNumber { get; init; }

    public int PageSize { get; init; }

    public bool ReturnTotalItemCount { get; init; }

    public Pagination AsPagination()
    {
        return new Pagination(PageNumber, PageSize, ReturnTotalItemCount);
    }
}
