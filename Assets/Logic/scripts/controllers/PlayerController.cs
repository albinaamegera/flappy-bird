using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("settings")]
    [Tooltip("скорость движения персонажа")]
    [SerializeField] private float _speed;
    [Tooltip("сила прыжка персонажа")]
    [SerializeField] private float _jumpForce;
    [Tooltip("слой препятствий")]
    [SerializeField] private LayerMask _obstacleLayer;

    Rigidbody2D _rb;
    CircleCollider2D _collider;
    Controls _controls;

    bool _isDisabled = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
        _controls = new();
    }
    private void Start()
    {
        _controls.Player.Enable();
        _controls.Player.PlayerAction.performed += c => Jump();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (_isDisabled) return;

        _rb.linearVelocity = new Vector2(_speed * Time.fixedDeltaTime, _rb.linearVelocityY);
    }
    private void Jump()
    {
        if (_isDisabled) return;

        _rb.linearVelocity = new Vector2(_rb.linearVelocityX, _jumpForce);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            OnGameOver();
        }
    }
    private void OnGameOver()
    {
        _isDisabled = true;
        _collider.enabled = false;
        GameManager.Instance.GameOver();
    }
}
