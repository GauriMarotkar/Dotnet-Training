

var weatherService = new WeatherService();

var temperatursInFiveDays = weatherService.GetTemperature("New York");
foreach (var temp in temperatursInFiveDays)
{
    Console.WriteLine($"Temperature in New York: {temp}");

}