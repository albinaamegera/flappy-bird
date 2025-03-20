using System;
using UnityEngine;
using UnityEngine.UI;

public class LinkView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private string _linkUrl;

    private void Start()
    {
        if (!_button)
        {
            Debug.LogWarning($"null reference exception : no button in {gameObject.name}");
            return;
        }
        if (String.IsNullOrEmpty(_linkUrl))
        {
            Debug.LogWarning($"link url is empty for button in {gameObject.name}");
            return;
        }
        _button.onClick.AddListener(OpenLink);
    }
    private void OpenLink() => Application.OpenURL(_linkUrl);
}
