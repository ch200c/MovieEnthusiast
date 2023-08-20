using AutoMapper;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Infrastructure.Mapping;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>();
    }
}

