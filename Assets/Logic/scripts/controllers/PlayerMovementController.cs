using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("settings")]
    [Tooltip("скорость движения персонажа")]
    [SerializeField] private float _speed;
    [Tooltip("сила прыжка персонажа")]
    [SerializeField] private float _jumpForce;

    Rigidbody2D _rb;
    bool _canMove = true;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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
    }
    private void Restart()
    {
        _rb.linearVelocity = Vector2.zero;
    }
    public void Enable()
    {
        _canMove = true;
        Restart();
    }
    public void Disable()
    {
        _canMove = false;
        Restart();
    }
}
