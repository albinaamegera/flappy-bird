using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class SelectButton : MonoBehaviour
{
    public UnityEvent onClick => _button.onClick;
    [Header("settings")]
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text; // todo : change to localization event

    public void Select()
    {
        _button.interactable = false;
        _text.text = "selected";
    }
    public void Unselect()
    {
        _button.interactable = true;
        _text.text = "select";
    }
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
