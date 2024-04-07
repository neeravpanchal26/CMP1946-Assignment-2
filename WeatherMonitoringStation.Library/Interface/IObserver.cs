/// <summary>
/// Represents an observer interface for monitoring weather conditions.
/// </summary>
namespace WeatherMonitoringStation.Library
{
    /// <summary>
    /// Defines the contract for objects that receive updates about weather conditions.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Receives updates about changes in temperature, humidity, and pressure.
        /// </summary>
        /// <param name="temperature">The new temperature value.</param>
        /// <param name="humidity">The new humidity value.</param>
        /// <param name="pressure">The new pressure value.</param>
        void Update(float temperature, float humidity, float pressure);
    }
}