namespace WeatherBuddy.Models.Conditions;

public class Visability(int visabilityPercentage)
{
    public int VisabilityPercentage { get; set; } = visabilityPercentage;
}