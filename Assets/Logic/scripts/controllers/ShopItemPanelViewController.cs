using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemPanelViewController : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private ShopContent _currentContent;
    [SerializeField] private ShopItemView _itemView;

    [Header("buttons")]
    [SerializeField] private Button _prevBtn;
    [SerializeField] private Button _nextBtn;

    private int _currentIndex = 0;

    private void Awake()
    {
        _prevBtn.onClick.AddListener(delegate { ShowItem(-1); });
        _nextBtn.onClick.AddListener(delegate { ShowItem(1); });
    }
    private void Start()
    {
        ShowItem(0);
    }
    private void CheckButtons()
    {
        _prevBtn.interactable = _currentIndex - 1 >= 0;
        _nextBtn.interactable = _currentIndex + 1 <= _currentContent.Items.Count() - 1;
    }
    private void ShowItem(int nextIndex)
    {
        _currentIndex += nextIndex;
        _itemView.UpdateView(_currentContent.Items.ElementAt(_currentIndex));
        CheckButtons();
    }
    private void OnDestroy()
    {
        _prevBtn.onClick.RemoveAllListeners();
        _nextBtn.onClick.RemoveAllListeners();
    }
}
