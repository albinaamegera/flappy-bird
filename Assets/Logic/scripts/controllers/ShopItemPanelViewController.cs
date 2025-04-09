using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemPanelViewController : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private ShopContent _currentContent;
    [SerializeField] private ShopItemView _itemView;
    [SerializeField] private ShopItemButtonController _btnController;

    [Header("buttons")]
    [SerializeField] private Button _prevBtn;
    [SerializeField] private Button _nextBtn;

    private ShopItemChecker _checker;
    private ShopItemSelector _selector;
    private ShopItemUnlocker _unlocker;

    private Wallet _wallet;

    private ShopItem _currentItem;
    private int _currentIndex = 0;

    public void Initialize(ShopItemChecker checker, ShopItemSelector selector, ShopItemUnlocker unlocker, Wallet wallet)
    {
        _checker = checker;
        _selector = selector;
        _unlocker = unlocker;
        _wallet = wallet;

        // check selected on start to update prefabs on level
        foreach (var item in _currentContent.Items)
        {
            _checker.Visit(item);
            if (_checker.IsSelected)
            {
                _selector.Visit(item);
                break;
            }
        }

        GetShopItem(0);
    }

    private void OnEnable()
    {
        _prevBtn.onClick.AddListener(delegate { GetShopItem(-1); });
        _nextBtn.onClick.AddListener(delegate { GetShopItem(1); });
        _btnController.onBuyButtonClick.AddListener(OnBuyItem);
        _btnController.onSelectionButtonClick.AddListener(OnSelectItem);
    }
    private void CheckButtons()
    {
        _prevBtn.interactable = _currentIndex - 1 >= 0;
        _nextBtn.interactable = _currentIndex + 1 <= _currentContent.Items.Count() - 1;
    }
    private void GetShopItem(int nextIndex)
    {
        _currentIndex += nextIndex;
        _currentItem = _currentContent.Items.ElementAt(_currentIndex);
        ShowItem();
    }
    private void ShowItem()
    {
        UpdateView();
        CheckButtons();
    }
    private void UpdateView()
    {
        bool locked;

        _checker.Visit(_currentItem);

        if (_checker.IsOpened)
        {
            _btnController.ShowSelectionButton(_checker.IsSelected);
            locked = false;
        }
        else
        {
            locked = true;
            int cost = _currentItem.Cost;
            _btnController.ShowBuyButton(cost, _wallet.IsEnough(cost));
        }
        _itemView.UpdateView(_currentItem, locked);
    }
    private void OnBuyItem()
    {
        if (!_wallet.IsEnough(_currentItem.Cost))
        {
            Debug.LogError("trying to by item but not enough money !!");
            return;
        }
        _wallet.Spend(_currentItem.Cost);
        _unlocker.Visit(_currentItem);

        UpdateView();
    }
    private void OnSelectItem()
    {
        _selector.Visit(_currentItem);
        UpdateView();
    }
    private void OnDisable()
    {
        _prevBtn.onClick.RemoveAllListeners();
        _nextBtn.onClick.RemoveAllListeners();
        _btnController.onBuyButtonClick.RemoveAllListeners();
        _btnController.onSelectionButtonClick.RemoveAllListeners();
    }
}
