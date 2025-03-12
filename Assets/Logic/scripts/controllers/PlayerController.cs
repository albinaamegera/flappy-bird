using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;

    PlayerMovementController _controller;
    Transform _transform;
    Controls _controls;

    private void Awake()
    {
        _controls = new();
        _controller = GetComponent<PlayerMovementController>();
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
        SetPosition();
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
