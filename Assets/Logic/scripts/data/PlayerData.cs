using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private PlayerSkins _selectedSkin;

    private List<PlayerSkins> _openedSkins;
    private SettingsData _settings;
    private ScoreCounter _counter;
    private Wallet _wallet;
    
    public PlayerData(PlayerDataConfig data) 
    {
        _selectedSkin = data.SelectedSkin.Skin;
        _openedSkins = new List<PlayerSkins> { _selectedSkin };
        _settings = new(data.MusicIsOn, data.SoundIsOn, data.LocaleId);
        _wallet = new(data.Money);
        _counter = new(DateTime.Now, data.Record);
    }
    [JsonConstructor]
    public PlayerData(PlayerSkins selectedSkin, List<PlayerSkins> openedSkins, SettingsData settings, ScoreCounter counter, Wallet wallet)
    {
        _selectedSkin = selectedSkin;
        _openedSkins = new List<PlayerSkins>(openedSkins);
        _settings = settings;
        _counter = counter;
        _wallet = wallet;
    }
    #region fields
    
    public PlayerSkins SelectedSkin => _selectedSkin;
    public IEnumerable<PlayerSkins> OpenedSkins => _openedSkins;

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
    private void SaveAfterChanges()
    {
        EventBus<OnDataSave>.RaiseEvent(new OnDataSave());
    }
}
