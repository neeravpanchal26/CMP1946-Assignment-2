﻿public class WeatherData : ISubject
{
    private static WeatherData instance;
    private List<IObserver> observers;
    private float temperature;
    private float humidity;
    private float pressure;
    private Random random;

    private WeatherData()
    {
        observers = new List<IObserver>();
        random = new Random();
    }

    public static WeatherData GetInstance()
    {
        if (instance == null)
        {
            instance = new WeatherData();
        }
        return instance;
    }

    public void UpdateWeatherData()
    {
        temperature = random.Next(0, 50);
        humidity = random.Next(0, 100);
        pressure = random.Next(900, 1100);
        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature, humidity, pressure);
        }
    }
}