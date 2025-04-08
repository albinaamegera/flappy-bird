using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public UnityEvent onClick => _button.onClick;

    [Header("settings")]
    [SerializeField] private Button _button;
    [SerializeField] private TextIntView _textView;
    [SerializeField] private Color _enabledColor;
    [SerializeField] private Color _disabledColor;

    public void UpdateText(int value) => _textView.Show(value);
    public void Lock()
    {
        _button.interactable = false;
        _textView.SetColor(_disabledColor);
    }
    public void Unlock()
    {
        _button.interactable = true;
        _textView.SetColor(_enabledColor);
    }
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
