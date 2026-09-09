namespace WeatherBuddy.Models.Forecast;
using System.Collections.Generic;

public class SevenDayForecast(List<Day> sevenDayForecasting)
{
    public List<Day> SevenDayForecasting {get; set;} = sevenDayForecasting;

}