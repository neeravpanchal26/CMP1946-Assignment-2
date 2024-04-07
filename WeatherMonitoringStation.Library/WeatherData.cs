/// <summary>
/// Represents a singleton class for weather data monitoring.
/// </summary>
namespace WeatherMonitoringStation.Library
{
    /// <summary>
    /// Represents the weather data class.
    /// </summary>
    public class WeatherData : ISubject
    {
        private static WeatherData _instance;
        private List<IObserver> observers;
        private float temperature;
        private float humidity;
        private float pressure;
        private Random random;

        /// <summary>
        /// Private constructor to initialize WeatherData instance.
        /// </summary>
        private WeatherData()
        {
            observers = new List<IObserver>();
            random = new Random();
        }

        /// <summary>
        /// Gets the instance of WeatherData class.
        /// </summary>
        /// <returns>The singleton instance of WeatherData class.</returns>
        public static WeatherData Get_instance()
        {
            if (_instance == null)
            {
                _instance = new WeatherData();
            }
            return _instance;
        }

        /// <summary>
        /// Updates weather data with random values and notifies observers.
        /// </summary>
        public void UpdateWeatherData()
        {
            temperature = random.Next(0, 50);
            humidity = random.Next(0, 100);
            pressure = random.Next(900, 1100);
            NotifyObservers();
        }

        /// <summary>
        /// Registers an observer.
        /// </summary>
        /// <param name="observer">The observer to be registered.</param>
        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// Removes an observer.
        /// </summary>
        /// <param name="observer">The observer to be removed.</param>
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// Notifies all registered observers with current weather data.
        /// </summary>
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature, humidity, pressure);
            }
        }
    }
}