using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private int _selectedSkin;

    private List<int> _openedSkins;

    private int _money;
    
    public PlayerData(PlayerDataConfig data) 
    {
        _money = data.Money;
        _selectedSkin = data.SelectedSkin.ItemId;
        _openedSkins = new List<int> { _selectedSkin };
    }
    [JsonConstructor]
    public PlayerData(int money, int selectedSkin, List<int> openedSkins)
    {
        _money = money;
        _selectedSkin = selectedSkin;
        _openedSkins = new List<int>(openedSkins);
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
            SaveAfterChanges();
        }
    }
    public int SelectedSkin => _selectedSkin;
    public IEnumerable<int> OpenedSkins => _openedSkins;
    #endregion

    #region skin methods
    public void OpenSkin(PlayerSkinItem skin)
    {
        if (IsSkinOpened(skin))
        {
            Debug.Log("this skin is already opend !!");
            return;
        }
        _openedSkins.Add(skin.ItemId);
        SaveAfterChanges();
    } 
    public bool IsSkinOpened(PlayerSkinItem skin) => _openedSkins.Contains(skin.ItemId);
    public bool IsSkinSelected(PlayerSkinItem skin) => skin.ItemId == _selectedSkin;
    public void SelectSkin(PlayerSkinItem skin)
    {
        _selectedSkin = skin.ItemId;
        SaveAfterChanges();
    }
    #endregion
    private void SaveAfterChanges()
    {
        EventBus<OnDataSave>.RaiseEvent(new OnDataSave());
    }
}
