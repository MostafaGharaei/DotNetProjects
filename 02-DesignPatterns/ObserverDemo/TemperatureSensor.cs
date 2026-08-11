using System;
using System.Collections.Generic;

namespace ObserverDemo;

/// <summary>
/// Concrete subject that maintains temperature and notifies observers
/// </summary>
public sealed class TemperatureSensor : ITemperatureSensor
{
    private readonly List<ITemperatureObserver> _observers = [];
    private double _temperature;

    public void Attach(ITemperatureObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Detach(ITemperatureObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature);
        }
    }

    public void SetTemperature(double celsius)
    {
        _temperature = celsius;
        Console.WriteLine($"🌡️ [Sensor] Temperature changed to {celsius}°C");
        Notify();
    }
}