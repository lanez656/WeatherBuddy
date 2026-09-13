namespace WeatherBuddy.Models;

public class CurrentWeather (double temperature, int weatherCode)
{
    public double Temperature {get; set;} = temperature;
    public int WeatherCode {get; set;} = weatherCode;
}