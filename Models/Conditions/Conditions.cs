namespace WeatherBuddy.Models.Conditions;

public class Conditions(Humidity humidity, Wind wind, Visability visability, UV uV)
{
    public Humidity Humidity { get; set; } = humidity;
    public Wind Wind { get; set; } = wind;
    public Visability Visability { get; set; } = visability;
    public UV UV { get; set; } = uV;
}