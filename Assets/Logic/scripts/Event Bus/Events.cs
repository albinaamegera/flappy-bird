using UnityEngine;

public interface IEvent { }

public struct OnGameStartedEvent : IEvent { }
public struct OnLevelStartedEvent : IEvent { }
public struct OnLevelRestartedEvent : IEvent { }
public struct OnLevelExitEvent : IEvent { }
public struct OnPlayerCollision : IEvent { }
public struct OnPlayerTransform : IEvent
{
    public Transform transform;
}
public struct OnCoinCollected : IEvent { }
public struct OnPointCollected : IEvent { }
