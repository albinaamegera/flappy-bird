using System;
using System.Collections.Generic;

public static class EventBus<T> where T : IEvent
{
    static readonly HashSet<IEventBinding<T>> _bindings = new HashSet<IEventBinding<T>>();

    public static void Register(IEventBinding<T> binding) => _bindings.Add(binding);
    public static void Deregister(IEventBinding<T> binding) => _bindings.Remove(binding);

    public static void RaiseEvent(T @event)
    {
        var snapshot = new HashSet<IEventBinding<T>>(_bindings);

        foreach(var binding in snapshot)
        {
            if (_bindings.Contains(binding))
            {
                binding.OnEvent.Invoke(@event);
                binding.OnEventNoArgs.Invoke();
            }
        }
    }
}
