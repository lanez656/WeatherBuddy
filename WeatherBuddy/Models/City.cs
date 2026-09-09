
using WeatherBuddy.Models.Conditions;
using WeatherBuddy.Models.Forecast;
using ConditionsModel = WeatherBuddy.Models.Conditions.Conditions;

namespace WeatherBuddy.Models;

public class City(string cityName, CurrentWeather currentWeather, HourlyForecast hourlyForecast, SevenDayForecast sevenDayForecast, ConditionsModel conditions)
{
    public string CityName {get; set;} = cityName;
    public CurrentWeather  CurrentWeather {get; set;} = currentWeather;
    public HourlyForecast HourlyForecast {get; set;} = hourlyForecast;
    public SevenDayForecast SevenDayForecast {get;set;} = sevenDayForecast;
    public ConditionsModel Conditions {get; set;} = conditions;

}