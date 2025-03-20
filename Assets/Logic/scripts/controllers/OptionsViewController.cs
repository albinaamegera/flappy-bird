using UnityEngine;
using UnityEngine.UI;

public class OptionsViewController : ViewController
{
    [Header("ui references")]
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _effectsToggle;
    [SerializeField] private Button _languageSwitcherBtn;

    private void Awake()
    {
        _musicToggle.onValueChanged.AddListener(ToggleMusic);
        _effectsToggle.onValueChanged.AddListener(ToggleEffects);
        _languageSwitcherBtn.onClick.AddListener(SwitchLanguage);
    }
    private void Start()
    {
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
        EventBus<OnMusicToggleValueChanged>.RaiseEvent(new OnMusicToggleValueChanged() { value = value });
    }
    private void ToggleEffects(bool value)
    {
        EventBus<OnEffectsToggleValueChanged>.RaiseEvent(new OnEffectsToggleValueChanged() { value = value });
    }
}
