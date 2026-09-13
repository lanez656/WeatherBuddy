namespace WeatherBuddy.Models.Forecast;

public class Day(string date, int weatherCode, double tempMax, double tempMin)
{
    public string Date {get; set;} = date;
    public int WeatherCode {get; set;} = weatherCode;
    public double TempMax {get; set;} = tempMax;
    public double TempMin {get; set;} = tempMin;
}