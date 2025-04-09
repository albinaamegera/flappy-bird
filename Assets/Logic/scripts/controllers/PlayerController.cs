using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
public class PlayerController : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private Vector3 _startPosition;

    PlayerSpriteController _spriteController;
    PlayerMovementController _movementController;
    CircleCollider2D _collider;
    Transform _transform;
    Controls _controls;

    private void Awake()
    {
        _controls = new();
        _spriteController = GetComponent<PlayerSpriteController>();
        _movementController = GetComponent<PlayerMovementController>();
        _collider = GetComponent<CircleCollider2D>();
        _transform = transform;
    }
    public void Setup(Sprite sprite)
    {
        EnableControls();
        SetPosition();
        SendTransform();
        UpdateSprite(sprite);
    }
    public void Restart()
    {
        Enable();
        SetPosition();
    }
    public void Disable()
    {
        DisableControls();
        _movementController.Disable();
        _collider.enabled = false;
    }
    public void Enable()
    {
        _collider.enabled = true;
        _movementController.Enable();
        EnableControls();
    }
    public void Remove()
    {
        DisableControls();
        Destroy(gameObject);
    }
    private void UpdateSprite(Sprite sprite) => _spriteController.UpdateSprite(sprite);
    private void SetPosition() => _transform.position = _startPosition;
    private void EnableControls()
    {
        _controls.Player.Enable();
        _controls.Player.PlayerAction.performed += c => _movementController.Jump();
    }
    private void DisableControls()
    {
        _controls.Player.PlayerAction.performed -= c => _movementController.Jump();
        _controls.Player.Disable();
    }
    private void SendTransform() => EventBus<OnPlayerTransform>.RaiseEvent(new OnPlayerTransform() { transform = _transform });
}
