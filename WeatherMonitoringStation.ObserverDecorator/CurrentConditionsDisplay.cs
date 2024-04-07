namespace WeatherMonitoringStation.ObserverDecorator;
using WeatherMonitoringStation.Library;
public class CurrentConditionsDisplay : IObserver, IDisplay
{
    private float temperature;
    private float humidity;
    private float pressure;
    private DateTime lastUpdate;

    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        lastUpdate = DateTime.Now;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Current conditions: {temperature}°C, Humidity: {humidity}%, Pressure: {pressure}hPa (Last update: {lastUpdate})");
    }
}