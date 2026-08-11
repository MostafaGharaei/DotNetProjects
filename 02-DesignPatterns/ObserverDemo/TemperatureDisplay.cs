using System;

namespace ObserverDemo;

/// <summary>
/// Concrete observer that displays temperature
/// </summary>
public sealed class TemperatureDisplay : ITemperatureObserver
{
    private readonly string _name;

    public TemperatureDisplay(string name)
    {
        _name = name;
    }

    public void Update(double temperature)
    {
        Console.WriteLine($"🖥️ [{_name}] Display: Current temperature is {temperature}°C");
    }
}