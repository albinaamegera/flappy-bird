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
    public IEnumerable<ShopItem> OpenedSkins => _openedSkins;

    public void OpenSkin(ShopItem skin)
    {
        if (_openedSkins.Contains(skin))
        {
            Debug.Log("this skin is already opend !!");
            return;
        }
        _openedSkins.Add(skin);
    } 
}
