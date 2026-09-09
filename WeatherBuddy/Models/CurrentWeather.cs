namespace WeatherBuddy.Models;

public class CurrentWeather (int temperature, int weatherCode)
{
    public int Temperature {get; set;} = temperature;
    public int WeatherCode {get; set;} = weatherCode;
}