using UnityEngine;

public class PlayerSpriteRotator : MonoBehaviour
{
    [Header("Настройки вращения")]
    [Tooltip("Скорость вращения в градусах/сек")]
    [SerializeField] private float rotationSpeed = 90f;

    [Tooltip("Максимальный угол вверх от начального положения")]
    [SerializeField] private float maxUpAngle = 80f;

    [Tooltip("Максимальный угол вниз от начального положения")]
    [SerializeField] private float maxDownAngle = -30f;

    [Tooltip("Трансформ для вращения")]
    [SerializeField] private Transform _targetTransform;

    private float currentAngle = 0f;
    private float initialRotation;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Сохраняем начальный угол поворота
        initialRotation = transform.eulerAngles.z;
    }

    private void Update()
    {
        HandleRotationInput();
        ApplyRotation();
    }

    private void HandleRotationInput()
    {
        // Рассчитываем изменение угла
        float angleChange = _rb.linearVelocityY * rotationSpeed * Time.deltaTime;
        currentAngle = Mathf.Clamp(currentAngle + angleChange, maxDownAngle, maxUpAngle);
    }

    private void ApplyRotation()
    {
        // Применяем поворот относительно начального положения
        _targetTransform.rotation = Quaternion.Euler(0f, 0f, initialRotation + currentAngle);
    }
}
