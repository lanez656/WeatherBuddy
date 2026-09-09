namespace WeatherBuddy.Models.Forecast;

using System.Collections.Generic;

public class HourlyForecast(List<Hour> hourlyForecasting)
{
    public List<Hour> HourlyForecasting {get; set;} = hourlyForecasting;
}