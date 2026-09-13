namespace WeatherBuddy.Models.Forecast;

public class Hour(int time, int weatherCode, double temperature, int percipitation)
{
    public int Time {get; set;} = time;
    public int WeatherCode {get; set;} = weatherCode;
    public double Temperature {get; set;} = temperature;
    public int Percipitation {get; set;} = percipitation;
}