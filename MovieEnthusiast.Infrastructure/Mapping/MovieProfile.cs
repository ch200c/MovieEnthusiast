using AutoMapper;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Application.Common.Requests;
using MovieEnthusiast.Application.Movies.Queries;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Infrastructure.Mapping;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<GetMoviesRequest, GetMoviesQuery>();
    }
}
