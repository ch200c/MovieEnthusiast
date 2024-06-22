using AutoFixture;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieEnthusiast.Api.Controllers;
using MovieEnthusiast.Application.Commands;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Application.Queries;
using NSubstitute;
using NUnit.Framework;

namespace MovieEnthusiast.Api.Tests.Controllers;

[TestFixture]
public class MovieControllerTests
{
    private IMediator _mediatorMock;
    private MovieController _sut;
    private Fixture _fixture;

    [SetUp]
    public void SetUp()
    {
        _mediatorMock = Substitute.For<IMediator>();
        _sut = new MovieController(_mediatorMock);
        _fixture = new Fixture();
    }

    [Test]
    public async Task Valid_GetMovies_ReturnsOkResult()
    {
        // Arrange
        _mediatorMock
            .Send(Arg.Any<GetMoviesQuery>(), Arg.Any<CancellationToken>())
            .Returns(_fixture.CreateMany<MovieDto>(1));

        // Act
        var result = await _sut.GetMovies(CancellationToken.None);

        // Assert
        result.Should().BeAssignableTo<OkObjectResult>();
    }

    [Test]
    public async Task Valid_AddMovie_ReturnOkResult()
    {
        // Arrange
        var movie = new MovieDto(null, "Shrek");
        const int TestId = 12;
        
        _mediatorMock.Send(Arg.Is<AddMovieCommand>(x => x.movie.Id == movie.Id && x.movie.Title == movie.Title))
            .Returns(TestId);

        // Act
        var result = await _sut.AddMovie(movie, CancellationToken.None);

        // Assert
        result.Should().BeAssignableTo<OkObjectResult>();
        var okResult = result as OkObjectResult;
        var id = (int?)okResult!.Value;
        id.Should().Be(TestId);
    }
}
