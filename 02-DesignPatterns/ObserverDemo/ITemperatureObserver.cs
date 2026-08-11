namespace ObserverDemo;

/// <summary>
/// Observer interface
/// </summary>
public interface ITemperatureObserver
{
    void Update(double temperature);
}