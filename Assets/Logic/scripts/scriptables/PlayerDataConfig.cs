using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "scriptables/player config", fileName = "new config")]
public class PlayerDataConfig : ScriptableObject
{
    public int Money => _money;
    public ShopItem SelectedSkin => _selectedSkin;

    [SerializeField] private int _money;
    [SerializeField] private ShopItem _selectedSkin;
}
