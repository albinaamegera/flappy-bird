using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "scriptables/player config", fileName = "new config")]
public class PlayerDataConfig : ScriptableObject
{
    public int Money => _money;
    public int Record => _record;
    public PlayerSkinItem SelectedSkin => _selectedSkin;

    [Header("player data")]
    [SerializeField] private int _money;
    [SerializeField] private int _record;
    [SerializeField] private PlayerSkinItem _selectedSkin;

    [Header("settings")]
    [SerializeField] private bool _musicIsOn;
    [SerializeField] private bool _soundIsOn;
    [SerializeField] private int _localeId;

    public bool MusicIsOn => _musicIsOn;
    public bool SoundIsOn => _soundIsOn;
    public int LocaleId => _localeId;
}
