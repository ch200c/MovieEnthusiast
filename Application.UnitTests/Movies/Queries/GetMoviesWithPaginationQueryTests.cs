using MovieEnthusiast.Application.Movies.Queries;
using MovieEnthusiast.Domain.Entities;
using NSubstitute;

namespace MovieEnthusiast.Application.UnitTests.Movies.Queries;
public class GetMoviesWithPaginationQueryTests
{
    //private readonly IMovieRepository _movieRepository = Substitute.For<IMovieRepository>();
    //private readonly IMapper _mapper;
    //private readonly GetMoviesWithPaginationQueryHandler _sut;

    //[Fact]
    //public Task Handle_ValidInput_ReturnsListOfMovies()
    //{
    //    _getMoviesWithPaginationQueryHandler = new GetMoviesWithPaginationQueryHandler(_movieRepository, _mapper);
    //    // Arrange
    //    Pagination pagination = new Pagination
    //    {
    //        PageNumber = 1,
    //        PageSize = 10
    //    };

    //    Movie movie = new()
    //    {
    //        Id = 1,
    //        Title = "Heat",
    //        ReleasedOn = DateTime.UtcNow
    //    };

    //    IList<Movie> movieList = new List<Movie>()
    //    {
    //        movie
    //    };

    //    _movieRepository.GetMovies(pagination).Returns(movieList);

    //    GetMoviesWithPaginationQuery getMoviesWithPaginationQuery = new();

    //    // Act
    //    var result = _sut.Handle(getMoviesWithPaginationQuery);

    //    // Assert
    //    _movieRepository.Received().GetMovies(pagination);
    //    Assert.True(result.Count == 1);
    //}
}