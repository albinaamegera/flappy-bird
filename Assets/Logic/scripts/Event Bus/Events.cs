using UnityEngine;

public interface IEvent { }

public struct OnGameStartedEvent : IEvent { }
public struct OnGameExitEvent : IEvent { }
public struct OnLevelStartedEvent : IEvent { }
public struct OnLevelRestartedEvent : IEvent { }
public struct OnLevelExitEvent : IEvent { }
public struct OnPlayerCollision : IEvent { }
public struct OnPlayerTransform : IEvent
{
    public Transform transform;
}
public struct OnCoinCollected : IEvent { }
public struct OnCoinValueChanged : IEvent
{
    public int value { get; set; }
}
public struct OnPointCollected : IEvent { }
public struct OnSoundEffectTriggered : IEvent
{
    public AudioClip clip;
}
public struct OnTubButtonPressed : IEvent
{
    public int id;
}
public struct OnMusicToggleValueChanged : IEvent
{
    public bool value;
}
public struct OnEffectsToggleValueChanged : IEvent
{
    public bool value;
}
public struct OnLocaleChanged : IEvent { }
