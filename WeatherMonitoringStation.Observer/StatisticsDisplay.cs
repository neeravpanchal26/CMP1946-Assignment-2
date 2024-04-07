using System;
using System.Collections.Generic;

public class StatisticsDisplay : IObserver, IDisplay
{
    private List<float> temperatureList;
    private float maxTemperature;
    private float minTemperature;
    private float averageTemperature;

    public StatisticsDisplay()
    {
        temperatureList = new List<float>();
        maxTemperature = float.MinValue;
        minTemperature = float.MaxValue;
        averageTemperature = 0.0f;
    }

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

    public void Display()
    {
        Console.WriteLine($"Weather Statistics: Max Temp: {maxTemperature}°C, Min Temp: {minTemperature}°C, Average Temp: {averageTemperature}°C");
    }
}
