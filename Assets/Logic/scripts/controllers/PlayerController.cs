using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("settings")]
    [Tooltip("скорость движения персонажа")]
    [SerializeField] private float _speed;
    [Tooltip("сила прыжка персонажа")]
    [SerializeField] private float _jumpForce;
    [Tooltip("начальная позиция")]
    [SerializeField] private Vector2 _startPosition;

    [Header("development")]
    [SerializeField] private bool _useOnDevelopment = false;

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
        if (_useOnDevelopment)
        {
            Debug.Log("on development is enabled !");
        }

        _controls.Player.Enable();
        _controls.Player.PlayerAction.performed += c => Jump();
        GameManager.Instance.OnLevelStart += Preparation;
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
        if (_useOnDevelopment) return;
        if (collision.collider.tag == "Obstacle")
        {
            OnGameOver();
        }
    }
    private void OnGameOver()
    {
        GameManager.Instance.GameOver();
        _isDisabled = true;
        _collider.enabled = false;
    }
    private void Preparation()
    {
        transform.position = _startPosition;
        _isDisabled = false;
        _rb.linearVelocity = Vector2.zero;
        _collider.enabled = true;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnLevelStart -= Preparation;
    }
}
