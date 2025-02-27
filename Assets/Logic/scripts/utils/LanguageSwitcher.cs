using UnityEngine;
using UnityEngine.Localization.Settings;


public class LanguageSwitcher : MonoBehaviour
{
    int _defaultId = 0;
    public void Switch(int nextId)
    {
        var localesLastId = LocalizationSettings.AvailableLocales.Locales.Count - 1;
        _defaultId = _defaultId + nextId > localesLastId ? 0 :
            _defaultId + nextId < 0 ? localesLastId :
            _defaultId + nextId;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_defaultId];
    }
}
