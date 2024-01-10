using AutoFixture;
using FluentAssertions;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Application.Queries;
using MovieEnthusiast.Domain.Entities;
using NSubstitute;
using NUnit.Framework;

namespace MovieEnthusiast.Application.Tests.Queries;

public class GetMoviesQueryHandlerTests
{
    private IMovieRepository _movieRepositoryMock;
    private Fixture _fixture;
    private GetMoviesQueryHandler _sut;

    [SetUp]
    public void SetUp()
    {
        _movieRepositoryMock = Substitute.For<IMovieRepository>();
        _sut = new GetMoviesQueryHandler(_movieRepositoryMock);
        _fixture = new Fixture();
    }

    [Test]
    public async Task ValidQuery_Handle_ReturnsCorrectNumberOfItems()
    {
        // Arrange
        var query = _fixture.Create<GetMoviesQuery>();
        var existingMovies = _fixture.CreateMany<Movie>(10).ToList();
        _movieRepositoryMock.GetMovies(Arg.Any<CancellationToken>()).Returns(existingMovies);

        // Act
        var result = await _sut.Handle(query, CancellationToken.None);

        // Assert
        result.Count().Should().Be(existingMovies.Count);
    }

    [Test]
    public async Task ValidQuery_Handle_ReturnsCorrectItem()
    {
        // Arrange
        var query = _fixture.Create<GetMoviesQuery>();
        var existingMovies = _fixture.CreateMany<Movie>(1).ToList();
        _movieRepositoryMock.GetMovies(Arg.Any<CancellationToken>()).Returns(existingMovies);

        // Act
        var result = (await _sut.Handle(query, CancellationToken.None)).First();

        // Assert
        var expected = existingMovies.First();

        result.Id.Should().Be(expected.Id);
        result.Title.Should().Be(expected.Title);
    }
}
    