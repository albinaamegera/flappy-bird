using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    [Header("references")]
    [SerializeField] private SpriteRenderer _renderer;

    public void UpdateSkin(Sprite sprite) => _renderer.sprite = sprite;
}
