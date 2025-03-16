using UnityEngine;

public class SoundEffectTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _currentClip;

    public void TriggerEffect()
    {
        EventBus<OnSoundEffectTriggered>.RaiseEvent(new OnSoundEffectTriggered() { clip = _currentClip });
    }
}
