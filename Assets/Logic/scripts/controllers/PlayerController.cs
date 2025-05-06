using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
public class PlayerController : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _continueOffset;

    float _disableXPos;
    Vector3 _continuePos;

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
        SetPosition(_startPosition);
        SendTransform();
        UpdateSprite(sprite);
    }
    public void Restart()
    {
        Enable();
        SetPosition(_startPosition);
    }
    public void Continue()
    {
        Enable();
        SetPosition(_continuePos);
    }
    public void Disable()
    {
        DisableControls();
        CalculateContinuePosition();
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
    private void SetPosition(Vector3 position) => _transform.position = position;
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
    private void CalculateContinuePosition()
    {
        _disableXPos = _transform.position.x;
        _continuePos = _continueOffset + new Vector3(_disableXPos, 0f, 0f);
    }
}
