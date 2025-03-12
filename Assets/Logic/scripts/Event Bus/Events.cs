using UnityEngine;

public interface IEvent { }

public struct OnGameStartedEvent : IEvent { }
public struct OnLevelStartedEvent : IEvent { }
public struct OnLevelRestartedEvent : IEvent { }
public struct OnLevelExitEvent : IEvent { }
public struct OnPlayerTransform : IEvent
{
    public Transform transform;
}
