/// <summary>
/// Represents a namespace for the WeatherMonitoringStation.Console application.
/// </summary>
namespace WeatherMonitoringStation.Console;

using System;
using WeatherMonitoringStation.Library;
using WeatherMonitoringStation.ObserverDecorator;
using WeatherMonitoringStation.Observer;

/// <summary>
/// Represents the main weather station class responsible for creating displays.
/// </summary>
public class WeatherStation
{
    /// <summary>
    /// Creates a display based on the specified type.
    /// </summary>
    /// <param name="displayType">The type of display to create.</param>
    /// <returns>An instance of the specified display type.</returns>
    public static IDisplay CreateDisplay(string displayType)
    {
        switch (displayType.ToLower())
        {
            case "currentconditions":
                return new CurrentConditionsDisplay();
            case "statistics":
                return new StatisticsDisplay();
            case "forecast":
                return new ForecastDisplay();
            default:
                throw new ArgumentException("Invalid display type specified.");
        }
    }
}

/// <summary>
/// Represents the entry point of the application.
/// </summary>
class Program
{
    /// <summary>
    /// The main method of the program.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    static void Main(string[] args)
    {
        WeatherData weatherData = WeatherData.Get_instance();
        IDisplay currentConditionsDisplay = WeatherStation.CreateDisplay("currentconditions");
        IDisplay statisticsDisplay = WeatherStation.CreateDisplay("statistics");
        IDisplay forecastDisplay = WeatherStation.CreateDisplay("forecast");
        weatherData.RegisterObserver((IObserver)currentConditionsDisplay);
        weatherData.RegisterObserver((IObserver)statisticsDisplay);
        weatherData.RegisterObserver((IObserver)forecastDisplay);
        Console.WriteLine("Weather data updates:");
        while (true)
        {
            weatherData.UpdateWeatherData();
            System.Threading.Thread.Sleep(5000);
        }
    }
}