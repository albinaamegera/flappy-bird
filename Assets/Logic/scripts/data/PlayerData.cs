using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private PlayerSkins _selectedSkin;
    private PlayerThemes _selectedTheme;

    private List<PlayerSkins> _openedSkins;
    private List<PlayerThemes> _openedThemes;
    private SettingsData _settings;
    private ScoreCounter _counter;
    private Wallet _wallet;
    
    public PlayerData(PlayerDataConfig data) 
    {
        _selectedSkin = data.SelectedSkin;
        _selectedTheme = data.SelectedTheme;
        _openedSkins = new List<PlayerSkins> { _selectedSkin };
        _openedThemes = new List<PlayerThemes> { _selectedTheme };
        _settings = new(data.MusicIsOn, data.SoundIsOn, data.LocaleId);
        _wallet = new(data.Money);
        _counter = new(DateTime.Now, data.Record);
    }
    [JsonConstructor]
    public PlayerData(PlayerSkins selectedSkin, PlayerThemes selectedTheme,
        List<PlayerSkins> openedSkins, List<PlayerThemes> openedThemes, SettingsData settings, ScoreCounter counter, Wallet wallet)
    {
        _selectedSkin = selectedSkin;
        _selectedTheme = selectedTheme;
        _openedSkins = new List<PlayerSkins>(openedSkins);
        _openedThemes = new List<PlayerThemes>(openedThemes);
        _settings = settings;
        _counter = counter;
        _wallet = wallet;
    }
    #region fields
    
    public PlayerSkins SelectedSkin => _selectedSkin;
    public PlayerThemes SelectedTheme => _selectedTheme;
    public IEnumerable<PlayerSkins> OpenedSkins => _openedSkins;
    public IEnumerable<PlayerThemes> OpenedThemes => _openedThemes;

    public SettingsData Settings => _settings;
    public ScoreCounter ScoreCounter => _counter;
    public Wallet Wallet => _wallet;
    #endregion

    #region skin methods
    public void OpenSkin(PlayerSkins skin)
    {
        if (IsSkinOpened(skin))
        {
            Debug.Log("this skin is already opend !!");
            return;
        }
        _openedSkins.Add(skin);
        //SaveAfterChanges();
    } 
    public bool IsSkinOpened(PlayerSkins skin) => _openedSkins.Contains(skin);
    public bool IsSkinSelected(PlayerSkins skin) => skin == _selectedSkin;
    public void SelectSkin(PlayerSkins skin)
    {
        _selectedSkin = skin;
        //SaveAfterChanges();
    }
    #endregion
    #region theme methods
    public void OpenTheme(PlayerThemes theme)
    {
        if (IsThemeOpened(theme))
        {
            Debug.Log("this theme is already opened !!");
            return;
        }
        _openedThemes.Add(theme);
        //SaveAfterChanges();
    }
    public bool IsThemeOpened(PlayerThemes theme) => _openedThemes.Contains(theme);
    public bool IsThemeSelected(PlayerThemes theme) => theme == _selectedTheme;
    public void SelectTheme(PlayerThemes theme)
    {
        _selectedTheme = theme;
        //SaveAfterChanges();
    }
    #endregion
    private void SaveAfterChanges()
    {
        EventBus<OnDataSave>.RaiseEvent(new OnDataSave());
    }
}
