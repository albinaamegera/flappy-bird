using UnityEngine;

[CreateAssetMenu(menuName = "scriptables/player config", fileName = "new config")]
public class PlayerDataConfig : ScriptableObject
{
    public int Money => _money;
    public int Record => _record;
    public PlayerSkins SelectedSkin => _selectedSkin;
    public PlayerThemes SelectedTheme => _selectedTheme;

    [Header("player data")]
    [SerializeField] private int _money;
    [SerializeField] private int _record;
    [SerializeField] private PlayerSkins _selectedSkin;
    [SerializeField] private PlayerThemes _selectedTheme; 

    [Header("settings")]
    [SerializeField] private bool _musicIsOn;
    [SerializeField] private bool _soundIsOn;
    [SerializeField] private int _localeId;

    public bool MusicIsOn => _musicIsOn;
    public bool SoundIsOn => _soundIsOn;
    public int LocaleId => _localeId;
}
