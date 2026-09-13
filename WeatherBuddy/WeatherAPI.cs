using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherBuddy.Models;
using WeatherBuddy.Models.Conditions;
using WeatherBuddy.Models.Forecast;


public class WeatherAPI
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<City> FetchCityDataAsync(string url, string cityName)
    {
        string jsonString = await client.GetStringAsync(url);
        using JsonDocument doc = JsonDocument.Parse(jsonString);
        JsonElement root = doc.RootElement;

       // City består af de andre elementer i model, så vi starter fra bunden og arbejder mod toppen(city)

       //Hour - HourlyForecast
       JsonElement hourlyElement = root.GetProperty("hourly");
       List<string> hourlyTimes = JsonSerializer.Deserialize<List<string>>(hourlyElement.GetProperty("time").GetRawText())!;
       List<int> hourlyWeatherCodes = JsonSerializer.Deserialize<List<int>>(hourlyElement.GetProperty("weather_code").GetRawText())!;
       List<double> hourlyTemps = JsonSerializer.Deserialize<List<double>>(hourlyElement.GetProperty("temperature_2m").GetRawText())!;
       List<int> precipitations = JsonSerializer.Deserialize<List<int>>(hourlyElement.GetProperty("precipitation_probability").GetRawText())!;

       List<Hour> hourList = new List<Hour>();
       for(int i = 0; i < hourlyTimes.Count; i++)
        {
            int hourOfDay = DateTime.Parse(hourlyTimes[i]).Hour;
            
            var hour = new Hour(
                time: hourOfDay,
                weatherCode: hourlyWeatherCodes[i],
                temperature: hourlyTemps[i],
                percipitation: precipitations[i]
            );

            hourList.Add(hour);
        }
        var hourlyForecast = new HourlyForecast(hourList);

        // Day - DailyForecast
        JsonElement dailyElement = root.GetProperty("daily");
        List<string> dates = JsonSerializer.Deserialize<List<string>>(dailyElement.GetProperty("time").GetRawText())!;
        List<int> dailyWeatherCodes = JsonSerializer.Deserialize<List<int>>(dailyElement.GetProperty("weather_code").GetRawText())!;
        List<double> dailyMaxTemps = JsonSerializer.Deserialize<List<double>>(dailyElement.GetProperty("temperature_2m_max").GetRawText())!;
        List<double> dailyMinTemps = JsonSerializer.Deserialize<List<double>>(dailyElement.GetProperty("temperature_2m_min").GetRawText())!;

        List<Day> dayList = new List<Day>();

        for (int i = 0; i < dates.Count; i++){

        var day = new Day(
            date: dates[i],
            weatherCode: dailyWeatherCodes[i],
            tempMax: dailyMaxTemps[i],
            tempMin: dailyMinTemps[i]
        );

        dayList.Add(day);
        }
        var dailyForecast = new DailyForecast(dayList);

        // Conditions - NEEDS CONFIGURATION
        var conditions = new Conditions(
            humidity: new Humidity(0),
            wind: new Wind(0,"N"),
            visability: new Visability(100),
            uV: new UV(5)
        );

        //CurrentWeather - NEEDS CONFIGURATION
        JsonElement currentElement = root.GetProperty("current");
        var currentTemp = currentElement.GetProperty("temperature_2m").GetDouble()!;
        var currentWeatherCode = currentElement.GetProperty("weather_code").GetInt32()!;

        var currentWeather = new CurrentWeather(
            temperature: currentTemp,
            weatherCode: currentWeatherCode
        );

        // Instantiate city
        var city = new City(
            cityName: cityName,
            currentWeather: currentWeather,
            hourlyForecast: hourlyForecast,
            dailyForecast: dailyForecast,
            conditions: conditions
            );

        return city;

    }
}

