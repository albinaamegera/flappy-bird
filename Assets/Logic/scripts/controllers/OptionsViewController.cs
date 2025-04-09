using UnityEngine;
using UnityEngine.UI;

public class OptionsViewController : ViewController
{
    [Header("ui references")]
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _effectsToggle;
    [SerializeField] private Button _languageSwitcherBtn;

    private IPersistentData _persistentData;

    private EventListener<OnDataInitialized> _onDataInitializedEventListener = new();

    private void Awake()
    {
        _musicToggle.onValueChanged.AddListener(ToggleMusic);
        _effectsToggle.onValueChanged.AddListener(ToggleEffects);
        _languageSwitcherBtn.onClick.AddListener(SwitchLanguage);
        _onDataInitializedEventListener.Add(e => Initialize(e.persistentData));
    }
    private void Initialize(IPersistentData persistentData)
    {
        _persistentData = persistentData;
        _musicToggle.isOn = _persistentData.PlayerData.Settings.MusicIsOn;
        _effectsToggle.isOn = _persistentData.PlayerData.Settings.SoundIsOn;
        CheckToggles();
    }
    private void SwitchLanguage()
    {
        EventBus<OnLocaleChanged>.RaiseEvent(new OnLocaleChanged());
    }
    private void CheckToggles()
    {
        ToggleMusic(_musicToggle.isOn);
        ToggleEffects(_effectsToggle.isOn);
    }
    private void ToggleMusic(bool value)
    {
        _persistentData.PlayerData.Settings.MusicIsOn = value;
        EventBus<OnMusicToggleValueChanged>.RaiseEvent(new OnMusicToggleValueChanged() { value = value });
    }
    private void ToggleEffects(bool value)
    {
        _persistentData.PlayerData.Settings.SoundIsOn = value;
        EventBus<OnEffectsToggleValueChanged>.RaiseEvent(new OnEffectsToggleValueChanged() { value = value });
    }
}
