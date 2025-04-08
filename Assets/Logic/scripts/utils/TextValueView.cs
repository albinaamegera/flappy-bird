using System;
using TMPro;
using UnityEngine;

public class TextValueView<T> : MonoBehaviour where T : IConvertible
{
    [SerializeField] private TMP_Text _textComponent;

    public void Show(T value)
    {
        _textComponent.text = value.ToString();
        gameObject.SetActive(true);
    }
    public void SetColor(Color color) => _textComponent.color = color;
    public void Hide() => gameObject.SetActive(false);
}
