using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private PlayerSkins _selectedSkin;

    private List<PlayerSkins> _openedSkins;

    private int _money;
    
    public PlayerData(PlayerDataConfig data) 
    {
        _money = data.Money;
        _selectedSkin = data.SelectedSkin.Skin;
        _openedSkins = new List<PlayerSkins> { _selectedSkin };
    }
    [JsonConstructor]
    public PlayerData(int money, PlayerSkins selectedSkin, List<PlayerSkins> openedSkins)
    {
        _money = money;
        _selectedSkin = selectedSkin;
        _openedSkins = new List<PlayerSkins>(openedSkins);
    }
    #region fields
    public int Money
    {
        get => _money;
        set
        {
            if (value < 0)
            {
                Debug.LogError($"value out of range : {value}");
                return;
            }
            _money = value;
            //SaveAfterChanges();
        }
    }
    public PlayerSkins SelectedSkin => _selectedSkin;
    public IEnumerable<PlayerSkins> OpenedSkins => _openedSkins;
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
