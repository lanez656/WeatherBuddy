
using System;

namespace WeatherBuddy.Models.Conditions;

public class Wind(int windSpeed, string direction)
{
    public int WindSpeed = windSpeed;
    public string Direction = direction;
}