using UnityEngine;
using UnityEngine.UI;

public class PlayerIconChanger : MonoBehaviour
{
    [SerializeField] private Image _icon;

    private EventListener<OnPlayerSkinChanged> _onPlayerSkinChangedEventListener = new();

    private void Awake()
    {
        _onPlayerSkinChangedEventListener.Add(e => UpdateIcon(e.Sprite));
    }
    private void UpdateIcon(Sprite sprite) => _icon.sprite = sprite;
}
