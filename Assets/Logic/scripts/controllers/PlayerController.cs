using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;

    PlayerMovementController _controller;
    CircleCollider2D _collider;
    Transform _transform;
    Controls _controls;

    private void Awake()
    {
        _controls = new();
        _controller = GetComponent<PlayerMovementController>();
        _collider = GetComponent<CircleCollider2D>();
        _transform = transform;
    }
    public void Setup()
    {
        EnableControls();
        SetPosition();
        SendTransform();
    }
    public void Restart()
    {
        Enable();
        SetPosition();
    }
    public void Disable()
    {
        DisableControls();
        _controller.Disable();
        _collider.enabled = false;
    }
    public void Enable()
    {
        _collider.enabled = true;
        _controller.Enable();
        EnableControls();
    }
    public void Remove()
    {
        DisableControls();
        Destroy(gameObject);
    }
    private void SetPosition() => _transform.position = _startPosition;
    private void EnableControls()
    {
        _controls.Player.Enable();
        _controls.Player.PlayerAction.performed += c => _controller.Jump();
    }
    private void DisableControls()
    {
        _controls.Player.PlayerAction.performed -= c => _controller.Jump();
        _controls.Player.Disable();
    }
    private void SendTransform() => EventBus<OnPlayerTransform>.RaiseEvent(new OnPlayerTransform() { transform = _transform });
}
