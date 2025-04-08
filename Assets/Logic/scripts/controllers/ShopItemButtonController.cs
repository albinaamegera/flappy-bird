using UnityEngine;
using UnityEngine.Events;

public class ShopItemButtonController : MonoBehaviour
{
    public UnityEvent onBuyButtonClick => _buyBtn.onClick;
    public UnityEvent onSelectionButtonClick => _selectionBtn.onClick;

    [Header("settings")]
    [Header("buttons")]
    [SerializeField] private BuyButton _buyBtn;
    [SerializeField] private SelectButton _selectionBtn;

    public void ShowBuyButton(int value, bool canBeClicked)
    {
        _selectionBtn.Hide();
        _buyBtn.Show();
        _buyBtn.UpdateText(value);
        if (canBeClicked)
        {
            _buyBtn.Unlock();
        }
        else
        {
            _buyBtn.Lock();
        }
    }
    public void ShowSelectionButton(bool isSelected)
    {
        _buyBtn.Hide();
        _selectionBtn.Show();
        if (isSelected)
        {
            _selectionBtn.Select();
        }
        else
        {
            _selectionBtn.Unselect();
        }
    }
}
