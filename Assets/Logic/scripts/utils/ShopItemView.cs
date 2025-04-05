using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [Header("ui referenses")]
    [SerializeField] private Image _icon;
    [SerializeField] private TextIntView _textView;
    [SerializeField] private GameObject _lockedIcon;
    [SerializeField] private GameObject _ownedInfo;
    [SerializeField] private GameObject _selectedInfo;

    public void UpdateView(ShopItem item)
    {
        _icon.sprite = item.Sprite;
        _textView.Show(item.Cost);
        _lockedIcon.SetActive(true);
        _ownedInfo.SetActive(false);
        _selectedInfo.SetActive(false);
    }
    public void UnLock()
    {
        _lockedIcon.SetActive(false);
        _ownedInfo.SetActive(true);
        _textView.Hide();
    }
    public void Select()
    {
        UnLock();
        _ownedInfo.SetActive(false);
        _selectedInfo.SetActive(true);
    }
}
