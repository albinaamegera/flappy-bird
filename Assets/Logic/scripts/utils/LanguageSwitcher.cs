using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageSwitcher : MonoBehaviour
{
    private int _localesCount = 0;
    private int _currentLocaleIndex = 0;
    // event listeners
    private EventListener<OnLocaleChanged> _onLocaleChangedEventListeners = new();

    private void Awake()
    {
        _onLocaleChangedEventListeners.Add(ChangeLocale);
    }
    private IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;

        _localesCount = LocalizationSettings.AvailableLocales.Locales.Count;

        ChangeLocale();
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
        ChangeLocale(_currentLocaleIndex);
    }
    private void ChangeLocale(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
