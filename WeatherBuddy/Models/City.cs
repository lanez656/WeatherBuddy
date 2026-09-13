
using WeatherBuddy.Models.Conditions;
using WeatherBuddy.Models.Forecast;
using ConditionsModel = WeatherBuddy.Models.Conditions.Conditions;

namespace WeatherBuddy.Models;

public class City(string cityName, CurrentWeather currentWeather, HourlyForecast hourlyForecast, DailyForecast dailyForecast, ConditionsModel conditions)
{
    public string CityName {get; set;} = cityName;
    public CurrentWeather  CurrentWeather {get; set;} = currentWeather;
    public HourlyForecast HourlyForecast {get; set;} = hourlyForecast;
    public DailyForecast DailyForecast {get;set;} = dailyForecast;
    public ConditionsModel Conditions {get; set;} = conditions;


    public override string ToString()
    {
        return $"City: {CityName}\n" +
               $"Current Temp: {CurrentWeather?.Temperature}°C, Weather Code: {CurrentWeather?.WeatherCode}\n" +
               $"Hourly Items: {HourlyForecast?.HourlyForecasting?.Count ?? 0}\n" +
               $"Daily Items: {DailyForecast?.DailyForecasting?.Count ?? 0}\n" +
               $"Conditions - Humidity: {Conditions?.Humidity?.HumidityCount}%, UV: {Conditions?.UV?.MaxUV}";
    }
}