using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("settings")]
    [Tooltip("скорость движения персонажа")]
    [SerializeField] private float _speed;
    [Tooltip("сила прыжка персонажа")]
    [SerializeField] private float _jumpForce;

    Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_speed * Time.fixedDeltaTime, _rb.linearVelocityY);
    }
    public void Jump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocityX, _jumpForce);
    }
    public void Restart()
    {
        _rb.linearVelocity = Vector2.zero;
    }
}
