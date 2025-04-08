using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private ShopItem _selectedSkin;

    private List<ShopItem> _openedSkins;

    private int _money;
    
    public PlayerData(PlayerDataConfig data) 
    {
        _money = data.Money;
        _selectedSkin = data.SelectedSkin;
        _openedSkins = new List<ShopItem> { _selectedSkin };
    }
    [JsonConstructor]
    public PlayerData(int money, ShopItem selectedSkin, List<ShopItem> openedSkins)
    {
        _money = money;
        _selectedSkin = selectedSkin;
        _openedSkins = new List<ShopItem>(openedSkins);
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
        }
    }
    public ShopItem SelectedSkin => _selectedSkin;
    public IEnumerable<ShopItem> OpenedSkins => _openedSkins;
    #endregion

    #region skin methods
    public void OpenSkin(ShopItem skin)
    {
        if (IsSkinOpened(skin))
        {
            Debug.Log("this skin is already opend !!");
            return;
        }
        _openedSkins.Add(skin);
    } 
    public bool IsSkinOpened(ShopItem skin) => _openedSkins.Contains(skin);
    public void SelectSkin(ShopItem skin) => _selectedSkin = skin;
    #endregion
}
