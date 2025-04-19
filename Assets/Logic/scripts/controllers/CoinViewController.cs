using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CoinViewController : MonoBehaviour
{
    [Header("View Components")]
    [SerializeField] private TMP_Text _text;

    [Header("callbacks")]
    [SerializeField] private UnityEvent _onViewUpdate;

    private Wallet _wallet;
    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.OnCoinsChanged += UpdateView;
    }
    private void UpdateView(int value)
    {
        _text.text = value.ToString();
        _onViewUpdate.Invoke();
    }
    private void OnEnable()
    {
        if (_wallet == null)
        {
            return;
        }
        _wallet.OnCoinsChanged += UpdateView;
    }
    private void OnDisable()
    {
        _wallet.OnCoinsChanged -= UpdateView;
    }
}
