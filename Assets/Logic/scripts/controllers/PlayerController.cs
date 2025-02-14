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

    Transform _transform;
    Rigidbody2D _rb;
    Controls _controls;

    private void Awake()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody2D>();
        _controls = new();
    }
    private void Start()
    {
        _controls.Player.Enable();
        _controls.Player.PlayerAction.performed += c => Jump();
    }
    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_speed * Time.fixedDeltaTime, _rb.linearVelocityY);
    }
    private void Jump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocityX, _jumpForce);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("game over");
        }
    }
}
