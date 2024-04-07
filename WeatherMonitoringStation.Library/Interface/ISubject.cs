/// <summary>
/// Represents the subject interface for the observer pattern.
/// </summary>
namespace WeatherMonitoringStation.Library;
public interface ISubject
{
    /// <summary>
    /// Registers an observer to receive updates from this subject.
    /// </summary>
    /// <param name="observer">The observer to register.</param>
    void RegisterObserver(IObserver observer);

    /// <summary>
    /// Removes an observer from the list of registered observers.
    /// </summary>
    /// <param name="observer">The observer to remove.</param>
    void RemoveObserver(IObserver observer);

    /// <summary>
    /// Notifies all registered observers about changes in the subject's state.
    /// </summary>
    void NotifyObservers();
}
