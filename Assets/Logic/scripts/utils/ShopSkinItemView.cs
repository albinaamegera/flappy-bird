using UnityEngine;
using UnityEngine.UI;

public class ShopSkinItemView : MonoBehaviour
{
    [Header("ui referenses")]
    [SerializeField] private Image _icon;
    [SerializeField] private TextIntView _textView;
    [SerializeField] private GameObject _lockedIcon;
    [SerializeField] private GameObject _selectedText;

    public void UpdateView(ShopItemData data)
    {
        _icon.sprite = data.Item.Sprite;
        _textView.Show(data.Item.Cost);

        CheckIfLocked(data.IsLocked);
        CheckIfSelected(data.IsSelected);
    }
    private void CheckIfLocked(bool isLocked)
    {
        _lockedIcon.SetActive(isLocked);
        if (!isLocked) 
            _textView.Hide();
    }
    private void CheckIfSelected(bool isSelected) => _selectedText.SetActive(isSelected);
}
