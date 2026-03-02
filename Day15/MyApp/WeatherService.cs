// Weather Service

// interface
public interface IWeatherService
{
    IEnumerable<double> GetTemperature(string city);
}

// Concrete implementation

public class WeatherService : IWeatherService
{
    public IEnumerable<double> GetTemperature(string city)
    {
        // City is not found
        throw new Exception("City not found");
        // DBContext
        // _context.Weather.Where(w => w.City == city).Take(5).Select(w => w.Temperature);
        yield return 20;
        yield return 21;
    }
}

public class MockWeatherService : IWeatherService
{
    public IEnumerable<double> GetTemperature(string city)
    {
        yield return 20;
        yield return 21;
        yield return 22;
        yield return 23;
        yield return 24;
    }
}

// FakeItEasy
// Moq