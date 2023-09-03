using AutoMapper;
using MovieEnthusiast.Api.Requests;
using MovieEnthusiast.Application.Movies.Queries;

namespace MovieEnthusiast.Infrastructure.Mapping;

public class PaginationPofile : Profile
{
    public PaginationPofile()
    {
        CreateMap(typeof(PaginatedRequest), typeof(PaginatedQuery<>));
    }
}
