using Moq;

namespace MyApp.Tests;

public class WeatherServiceTests
{
    [Fact]
    public void GetWeather_ReturnsExpectedResult()
    {
        // Arrange
        // IWeatherService weatherService = new WeatherService();

        var mockWeatherService = new Mock<IWeatherService>();

        mockWeatherService
            .Setup(x => x.GetTemperature(It.IsAny<string>()))
            .Returns(
                new List<double> { 30, 32, 28, 31, 29 }
            );
        var weatherService = mockWeatherService.Object;

        var expectedCount = 5;


        // Act
        var result = weatherService.GetTemperature("New York");
        var actualCount = result.Count();

        foreach (var temp in result)
        {
            Console.WriteLine(temp);
        }

        // Assert
        //Assert.Equal(1, mockWeatherService);
        Assert.NotNull(result);
        Assert.Equal(expectedCount, actualCount);
    }


    [Fact]
    public void GetWeather_ThrowsException()
    {
        // Arrange
        // IWeatherService weatherService = new WeatherService();

        var mockWeatherService = new Mock<IWeatherService>();

        mockWeatherService
            .Setup(x => x.GetTemperature(It.IsAny<string>()))
            .Throws(new Exception("City Not Found"));
        var weatherService = mockWeatherService.Object;


        // Assert
        //Assert.Equal(1, mockWeatherService);
        Assert.Throws<Exception>(() => weatherService.GetTemperature("Some dummy city"));
    }
}