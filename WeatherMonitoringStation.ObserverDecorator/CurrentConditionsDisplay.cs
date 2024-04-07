/// <summary>
/// Concrete observer class for displaying current weather conditions.
/// </summary>
namespace WeatherMonitoringStation.ObserverDecorator;

using WeatherMonitoringStation.Library;
using System;

/// <summary>
/// Represents the current conditions display.
/// </summary>
public class CurrentConditionsDisplay : IObserver, IDisplay
{
    private float temperature;
    private float humidity;
    private float pressure;
    private DateTime lastUpdate;

    /// <summary>
    /// Updates the current weather conditions.
    /// </summary>
    /// <param name="temperature">The current temperature.</param>
    /// <param name="humidity">The current humidity.</param>
    /// <param name="pressure">The current pressure.</param>
    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        lastUpdate = DateTime.Now;
        Display();
    }

    /// <summary>
    /// Displays the current weather conditions.
    /// </summary>
    public void Display()
    {
        Console.WriteLine($"Current conditions: {temperature}°C, Humidity: {humidity}%, Pressure: {pressure}hPa (Last update: {lastUpdate})");
    }
}