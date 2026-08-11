using System;

namespace ObserverDemo;

/// <summary>
/// Subject interface (Observable)
/// </summary>
public interface ITemperatureSensor
{
    void Attach(ITemperatureObserver observer);
    void Detach(ITemperatureObserver observer);
    void Notify();
    void SetTemperature(double celsius);
}