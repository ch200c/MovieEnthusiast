using AutoMapper;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Application.Movies.Queries;
using MovieEnthusiast.Domain.Entities;
using MovieEnthusiast.Infrastructure.Mapping;
using NSubstitute;
using Xunit;

namespace MovieEnthusiast.Application.UnitTests.Movies.Queries;

public class GetMoviesWithPaginationQueryTests
{
    private readonly IMovieRepository _movieRepository = Substitute.For<IMovieRepository>();
    private readonly IMapper _mapper;
    private readonly GetMoviesWithPaginationQueryHandler _sut;

    public GetMoviesWithPaginationQueryTests()
    {
        MapperConfiguration mapperConfig = new(
        cfg =>
        {
            cfg.AddProfile(new MovieProfile());
            cfg.AddProfile(new PaginationPofile());
        });

        _mapper = new Mapper(mapperConfig);

        _sut = new GetMoviesWithPaginationQueryHandler(_movieRepository, _mapper);
    }

    [Fact]
    public async Task Handle_ValidInput_ReturnsListOfMovies()
    {
        // Arrange
        const int PageNumber = 1;
        const int PageSize = 10;
        const int TotalCount = 200;
        const int ExpectedTotalPages = 20;

        var query = new GetMoviesQuery()
        {
            PageNumber = PageNumber,
            PageSize = PageSize
        };

        const int id = 10;
        const string title = "Trapper";
        DateTime releasedOn = DateTime.UtcNow;

        var movie = new Movie()
        {
            Id = id,
            Title = title,
            ReleasedOn = releasedOn
        };

        var expectedResult = new MovieDto(id, title, releasedOn);

        var paginatedMovies = new PaginatedEntity<Movie>
        {
            Items = new List<Movie>() { movie },
            TotalItemCount = TotalCount
        };

        _movieRepository
            .GetMovies(Arg.Any<Pagination>(), CancellationToken.None)
            .Returns(paginatedMovies);

        // Act
        var result = await _sut.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.Items.First().Equals(expectedResult));
        Assert.True(result.PageNumber ==  PageNumber);
        Assert.True(result.TotalPages == ExpectedTotalPages);
        Assert.True(result.TotalCount == TotalCount);
    }

    [Fact]
    public async Task Handle_ValidInput_ReturnsListOfMoviesWithNoTotalItemCount()
    {
        // Arrange
        const int PageNumber = 1;
        const int PageSize = 10;

        var query = new GetMoviesQuery()
        {
            PageNumber = PageNumber,
            PageSize = PageSize,
            ReturnTotalItemCount = false
        };

        const int id = 10;
        const string title = "Trapper";
        DateTime releasedOn = DateTime.UtcNow;

        var movie = new Movie()
        {
            Id = id,
            Title = title,
            ReleasedOn = releasedOn
        };

        var expectedResult = new MovieDto(id, title, releasedOn);

        var paginatedMovies = new PaginatedEntity<Movie>
        {
            Items = new List<Movie>() { movie }
        };

        _movieRepository
            .GetMovies(Arg.Any<Pagination>(), CancellationToken.None)
            .Returns(paginatedMovies);

        // Act
        var result = await _sut.Handle(query, CancellationToken.None);

        // Assert
        Assert.True(result.Items.First().Equals(expectedResult));
        Assert.True(result.PageNumber == PageNumber);
        Assert.True(result.TotalPages == null);
        Assert.True(result.TotalCount == null);
    }
}