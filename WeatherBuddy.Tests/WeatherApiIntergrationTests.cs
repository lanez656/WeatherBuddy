using System.Threading.Tasks;
using WeatherBuddy.Models;
using Xunit;

namespace WeatherBuddy.Tests;

public class WeatherApiIntegrationTests
{
    [Fact]
    public async Task FetchCityDataAsync_FromOpenMeteoApi_InstantiatesCityCorrectly()
    {
        // Arrange
        string url = "https://api.open-meteo.com/v1/forecast?latitude=55.6759&longitude=12.5655&daily=weather_code,temperature_2m_max,temperature_2m_min&hourly=temperature_2m,weather_code,precipitation_probability&current=temperature_2m,weather_code&timezone=Europe%2FBerlin";
        string cityName = "Copenhagen";

        // Act
        City city = await WeatherAPI.FetchCityDataAsync(url, cityName);

        // Assert
        Assert.NotNull(city);

        // Verify Current Weather
        Assert.NotNull(city.CurrentWeather);

        // Verify Hourly Forecast & nested Hours
        Assert.NotNull(city.HourlyForecast);
        Assert.NotEmpty(city.HourlyForecast.HourlyForecasting);
        Assert.Equal(168, city.HourlyForecast.HourlyForecasting.Count);

        // Verify Daily Forecast & nested Days
        Assert.NotNull(city.DailyForecast);
        Assert.NotEmpty(city.DailyForecast.DailyForecasting);
        Assert.Equal(7, city.DailyForecast.DailyForecasting.Count);

        // Verify Conditions
        Assert.NotNull(city.Conditions);
        Assert.Equal(5, city.Conditions.UV.MaxUV);
        Assert.Equal(100, city.Conditions.Visability.VisabilityPercentage);

        Console.WriteLine(city.ToString());
    }
}