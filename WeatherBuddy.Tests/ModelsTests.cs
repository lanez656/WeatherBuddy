using System.Collections.Generic;
using System.Reflection;
using Avalonia.Controls;
using WeatherBuddy.Models;
using WeatherBuddy.Models.Conditions;
using WeatherBuddy.Models.Forecast;
using Xunit;

namespace WeatherBuddy.Tests;

public class ModelTests
{
    [Fact]
    public void Test_ConditionsModels_InstantiateCorrectly()
    {
        // Setup
        var humidity = new Humidity(65);
        var wind = new Wind(15, "NE");
        var visability = new Visability(100);
        var uv = new UV(5);
        var conditions = new Conditions(humidity, wind, visability, uv);

        // Assert
        Assert.Equal(65, humidity.HumidityCount);
        Assert.Equal(15, wind.WindSpeed);
        Assert.Equal("NE", wind.Direction);
        Assert.Equal(100, visability.VisabilityPercentage);
        Assert.Equal(5, uv.MaxUV);

        Assert.Equal(humidity, conditions.Humidity);
        Assert.Equal(wind, conditions.Wind);
        Assert.Equal(visability, conditions.Visability);
        Assert.Equal(uv, conditions.UV);
    }

    [Fact]
    public void Test_CurrentWeather_InstatiateCorrectly()
    {
        //Setup
        var currentWeather = new CurrentWeather(18, 1);

        //Assert
        Assert.Equal(18, currentWeather.Temperature);
        Assert.Equal(1, currentWeather.WeatherCode);
    }

    [Fact]
    public void Test_7DayForecast_InstatiateCorrectly()
    {
        
        string[] days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
        var dayList = new List<Day>();
        
        //Setup
        for (int i = 0; i<days.Length; i++)
        {
            dayList.Add(new Day(days[i], 0, 22, 16));
        }

        //Assert
        Assert.Equal(7, dayList.Count);
        foreach (Day d in dayList)
        {
            Assert.NotNull(d);
            Assert.NotEmpty(d.Name);
            Assert.Equal(0, d.WeatherCode);
            Assert.Equal(22, d.TempMax);
            Assert.Equal(16, d.TempMin);
        }
    }

    [Fact]
    public void HourlyForecast_ShouldContain24HoursInCorrectOrder()

    {
        // Setup
        var hours = new List<Hour>();

        for (int i = 0; i < 24; i++)
        {
            hours.Add(new Hour(time: i, weatherCode: i + 1, temperature: i + 10, percipitation: i));
        }

        var forecast = new HourlyForecast(hours);

        // Assert
        Assert.Equal(24, forecast.HourlyForecasting.Count);

        for (int i = 0; i < 24; i++)
        {
            Assert.Equal(i, forecast.HourlyForecasting[i].Time);
            Assert.Equal(i + 1, forecast.HourlyForecasting[i].WeatherCode);
            Assert.Equal(i + 10, forecast.HourlyForecasting[i].Temperature);
            Assert.Equal(i, forecast.HourlyForecasting[i].Percipitation);
        }

    }
}