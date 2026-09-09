namespace WeatherBuddy.Models.Forecast;

public class Day(string name, int weatherCode, int tempMax, int tempMin)
{
    public string Name {get; set;} = name;
    public int WeatherCode {get; set;} = weatherCode;
    public int TempMax {get; set;} = tempMax;
    public int TempMin {get; set;} = tempMin;
}