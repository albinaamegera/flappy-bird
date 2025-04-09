using System;

public class EventListener<T> where T : IEvent
{
    private EventBinding<T> _binding;

    public EventListener()
    {
        _binding = new EventBinding<T>();
        EventBus<T>.Register(_binding);
    }
    public void Add(Action<T> action) => _binding.Add(action);
    public void Add(Action action) => _binding.Add(action);

    public void Remove(Action<T> action) => _binding.Remove(action);
    public void Remove(Action action) => _binding.Remove(action);
}
