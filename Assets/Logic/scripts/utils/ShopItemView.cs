using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [Header("ui referenses")]
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _lockedIcon;

    public void UpdateView(ShopItem item, bool locked)
    {
        _icon.sprite = item.Sprite;
        _lockedIcon.SetActive(locked);
    }
}
