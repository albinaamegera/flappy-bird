using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageSwitcher : MonoBehaviour
{
    private int _localesCount = 0;
    private int _currentLocaleIndex = 0;

    private IPersistentData _persistentData;
    // event listeners
    private EventListener<OnLocaleChanged> _onLocaleChangedEventListeners = new();

    private void Awake()
    {
        _onLocaleChangedEventListeners.Add(ChangeLocale);
    }
    
    public void InitializeData(IPersistentData persistentData)
    {
        _persistentData = persistentData;

        StartCoroutine(SetLocale());
    }
    public void ChangeLocale()
    {
        if (_currentLocaleIndex + 1 > _localesCount - 1)
        {
            _currentLocaleIndex = 0;
        }
        else
        {
            _currentLocaleIndex++;
        }
        _persistentData.PlayerData.Settings.CurrentLocaleId = _currentLocaleIndex;
        ChangeLocale(_currentLocaleIndex);
    }
    private void ChangeLocale(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
    private IEnumerator SetLocale()
    {
        yield return LocalizationSettings.InitializationOperation;

        _localesCount = LocalizationSettings.AvailableLocales.Locales.Count;
        _currentLocaleIndex = _persistentData.PlayerData.Settings.CurrentLocaleId;
        ChangeLocale(_currentLocaleIndex);
    }
}
