using Newtonsoft.Json;
using UnityEngine.Localization.Settings;

public class SettingsData 
{
    public bool MusicIsOn { get; set; }
    public bool SoundIsOn { get; set; }
    public int CurrentLocaleId { get; set; }

    [JsonConstructor]
    public SettingsData(bool musicIsOn, bool soundIsOn, int localeId)
    {
        MusicIsOn = musicIsOn;
        SoundIsOn = soundIsOn;
        CurrentLocaleId = localeId;
    }
}
