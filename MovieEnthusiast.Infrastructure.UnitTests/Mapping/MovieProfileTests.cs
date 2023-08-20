using AutoMapper;
using MovieEnthusiast.Infrastructure.Mapping;

namespace MovieEnthusiast.Infrastructure.UnitTests.Mapping;

public class MovieProfileTests
{
    [Fact]
    public void ValidateMappingConfigurationTest()
    {
        MapperConfiguration mapperConfig = new MapperConfiguration(
        cfg =>
        {
            cfg.AddProfile(new MovieProfile());
        });

        IMapper mapper = new Mapper(mapperConfig);

        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}
