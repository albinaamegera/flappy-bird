using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("settings")]
    [SerializeField] private AudioSource _mainThemeSource;
    [SerializeField] private AudioSource _clipSoundSource;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public void PlayEffect(AudioClip clip)
    {
        _clipSoundSource.PlayOneShot(clip);
    }
    public void ChangeMusicVolume(float value)
    {
        _mainThemeSource.volume = value;
    }
    public void ChangeSoundVolume(float value)
    {
        _clipSoundSource.volume = value;
    }
}
