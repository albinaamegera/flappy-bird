using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("settings")]
    [SerializeField] private AudioSource _mainThemeSource;
    [SerializeField] private AudioSource _clipSoundSource;

    private void Awake()
    {
        Instance = this;
    }
    public void PlayEffect(AudioClip clip)
    {
        _clipSoundSource.PlayOneShot(clip);
    }
}
