using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    public void UpdateSprite(Sprite sprite) => _renderer.sprite = sprite;
}
