using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementController : MonoBehaviour
{
    [Header("settings")]
    [Tooltip("скорость движения персонажа")]
    [SerializeField] private float _speed;
    [Tooltip("сила прыжка персонажа")]
    [SerializeField] private float _jumpForce;

    [Header("callbacks")]
    [Tooltip("jump callback")]
    [SerializeField] private UnityEvent _jumpCallback;

    Rigidbody2D _rb;
    float _gravityScale;
    bool _canMove = true;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gravityScale = _rb.gravityScale;
    }
    private void FixedUpdate()
    {
        if (_canMove)
        {
            _rb.linearVelocity = new Vector2(_speed * Time.fixedDeltaTime, _rb.linearVelocityY);
        }
    }
    public void Jump()
    {
        if (!_canMove) return;
        _rb.linearVelocity = new Vector2(_rb.linearVelocityX, _jumpForce);
        _jumpCallback.Invoke();
    }
    private void Restart()
    {
        _rb.linearVelocity = Vector2.zero;
    }
    public void Enable()
    {
        _canMove = true;
        _rb.gravityScale = _gravityScale;
        Restart();
    }
    public void EnableWithZeroGravity()
    {
        _rb.gravityScale = 0;
        Restart();
    }
    public void Disable()
    {
        _canMove = false;
        Restart();
    }
}
