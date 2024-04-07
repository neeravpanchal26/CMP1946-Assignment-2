using System;
public class ForecastDisplay : IObserver, IDisplay
{
    private float lastTemperature;
    private float currentTemperature;
    private string forecast;

    public ForecastDisplay()
    {
        lastTemperature = 0.0f;
        currentTemperature = 0.0f;
        forecast = "No forecast available";
    }

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

    public void Display()
    {
        Console.WriteLine($"Weather Forecast: {forecast}");
    }
}
