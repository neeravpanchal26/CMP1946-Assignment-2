/// <summary>
/// The ForecastDisplay class represents an observer that displays weather forecasts.
/// </summary>
namespace WeatherMonitoringStation.Observer
{
    using WeatherMonitoringStation.Library;
    using System;

    /// <summary>
    /// Represents a display for weather forecasts.
    /// </summary>
    public class ForecastDisplay : IObserver, IDisplay
    {
        private float lastTemperature;
        private float currentTemperature;
        private string forecast;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForecastDisplay"/> class.
        /// </summary>
        public ForecastDisplay()
        {
            lastTemperature = 0.0f;
            currentTemperature = 0.0f;
            forecast = "No forecast available";
        }

        /// <summary>
        /// Updates the weather forecast based on the temperature change.
        /// </summary>
        /// <param name="temperature">The current temperature.</param>
        /// <param name="humidity">The current humidity (not used).</param>
        /// <param name="pressure">The current pressure (not used).</param>
        public void Update(float temperature, float humidity, float pressure)
        {
            lastTemperature = currentTemperature;
            currentTemperature = temperature;
            if (currentTemperature > lastTemperature)
            {
                forecast = "Improving weather on the way!";
            }
            else if (currentTemperature < lastTemperature)
            {
                forecast = "Watch out for cooler weather!";
            }
            else
            {
                forecast = "More of the same";
            }
            Display();
        }

        /// <summary>
        /// Displays the weather forecast.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Weather Forecast: {forecast}");
        }
    }
}