using System;

namespace ObserverDemo;

/// <summary>
/// Concrete observer that triggers alerts
/// </summary>
public sealed class AlertSystem : ITemperatureObserver
{
    private readonly double _threshold;

    public AlertSystem(double threshold)
    {
        _threshold = threshold;
    }

    public void Update(double temperature)
    {
        if (temperature > _threshold)
        {
            Console.WriteLine($"🚨 [Alert] WARNING: Temperature {temperature}°C exceeds threshold {_threshold}°C!");
        }
        else
        {
            Console.WriteLine($"✅ [Alert] Temperature {temperature}°C is within safe range.");
        }
    }
}