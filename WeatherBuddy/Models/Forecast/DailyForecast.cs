namespace WeatherBuddy.Models.Forecast;
using System.Collections.Generic;

public class DailyForecast(List<Day> dailyForecasting)
{
    public List<Day> DailyForecasting {get; set;} = dailyForecasting;

}