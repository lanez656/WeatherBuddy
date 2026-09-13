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

    // rewrite test for dates


    [Fact]
    public void HourlyForecast_ShouldContain24HoursInCorrectOrder()

    {
        // Setup
        var hours = new List<Hour>();

        for (int i = 0; i < 24*7; i++)
        {
            hours.Add(new Hour(time: i, weatherCode: i + 1, temperature: i + 10, percipitation: i));
        }

        var forecast = new HourlyForecast(hours);

        // Assert
        Assert.Equal(24*7, forecast.HourlyForecasting.Count);

        for (int i = 0; i < 24*7; i++)
        {
            Assert.Equal(i, forecast.HourlyForecasting[i].Time);
            Assert.Equal(i + 1, forecast.HourlyForecasting[i].WeatherCode);
            Assert.Equal(i + 10, forecast.HourlyForecasting[i].Temperature);
            Assert.Equal(i, forecast.HourlyForecasting[i].Percipitation);
        }
    }
}