using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("audio sources")]
    [Tooltip("main source to play main theme music")]
    [SerializeField] private AudioSource _mainSource;

    [Tooltip("source to play sound effects")]
    [SerializeField] private AudioSource _effectsSource;

    // event listeners
    private EventListener<OnSoundEffectTriggered> _onSoundEffectEventListener = new();

    private void Awake()
    {
        _onSoundEffectEventListener.Add(e => PlaySoundEffect(e.clip));
    }
    private void PlaySoundEffect(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }
}
