using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "scriptables/player config", fileName = "new config")]
public class PlayerDataConfig : ScriptableObject
{
    public int Money => _money;
    public PlayerSkinItem SelectedSkin => _selectedSkin;

    [SerializeField] private int _money;
    [SerializeField] private PlayerSkinItem _selectedSkin;
}
