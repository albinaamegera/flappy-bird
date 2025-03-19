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
    private EventListener<OnMusicToggleValueChanged> _onMusicMuteEventListener = new();
    private EventListener<OnEffectsToggleValueChanged> _onEffectsMuteEventListener = new();

    private void Awake()
    {
        _onSoundEffectEventListener.Add(e => PlaySoundEffect(e.clip));
        _onMusicMuteEventListener.Add(e => _mainSource.mute = !e.value);
        _onEffectsMuteEventListener.Add(e => _effectsSource.mute = !e.value);
    }
    private void PlaySoundEffect(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }
}
