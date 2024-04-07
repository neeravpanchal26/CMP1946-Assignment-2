namespace WeatherMonitoringStation.Console;
using System;
using WeatherMonitoringStation.Library;
using WeatherMonitoringStation.ObserverDecorator;
using WeatherMonitoringStation.Observer;
public class WeatherStation
{
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
class Program
{
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
