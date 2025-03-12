using TMPro;
using UnityEngine;

public class CoinViewController : MonoBehaviour
{
    [Header("View Components")]
    [SerializeField] private TMP_Text _text;

    private int _coins = 0;

    // listeners
    private EventListener<OnCoinCollected> _onCoinCollectedEventListener = new();
    // todo : on ubdate coins listener to show current value

    private void Awake()
    {
        _onCoinCollectedEventListener.Add(OnCollectCoin);
    }
    private void OnCollectCoin()
    {
        _coins++;
        UpdateView();
    }
    private void UpdateView() => _text.text = _coins.ToString();
}
