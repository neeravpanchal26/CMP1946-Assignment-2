/// <summary>
/// Concrete observer implementation responsible for displaying statistics (max temperature, min temperature, and average temperature).
/// </summary>
namespace WeatherMonitoringStation.Observer
{
    using WeatherMonitoringStation.Library;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a statistics display observer.
    /// </summary>
    public class StatisticsDisplay : IObserver, IDisplay
    {
        private List<float> temperatureList;
        private float maxTemperature;
        private float minTemperature;
        private float averageTemperature;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsDisplay"/> class.
        /// </summary>
        public StatisticsDisplay()
        {
            temperatureList = new List<float>();
            maxTemperature = float.MinValue;
            minTemperature = float.MaxValue;
            averageTemperature = 0.0f;
        }

        /// <summary>
        /// Update method to receive temperature changes and update statistics.
        /// </summary>
        /// <param name="temperature">The new temperature reading.</param>
        /// <param name="humidity">The humidity reading.</param>
        /// <param name="pressure">The pressure reading.</param>
        public void Update(float temperature, float humidity, float pressure)
        {
            temperatureList.Add(temperature);
            if (temperature > maxTemperature)
            {
                maxTemperature = temperature;
            }
            if (temperature < minTemperature)
            {
                minTemperature = temperature;
            }
            averageTemperature = temperatureList.Sum() / temperatureList.Count;
            Display();
        }

        /// <summary>
        /// Display method to show statistics on the console.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Weather Statistics: Max Temp: {maxTemperature}°C, Min Temp: {minTemperature}°C, Average Temp: {averageTemperature}°C");
        }
    }
}