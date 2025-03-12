using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRotator : MonoBehaviour
{
    [Header("Трансформ для вращения")]
    [SerializeField] private Transform _transform;
    [Header("Настройки вращения")]
    [Tooltip("Скорость вращения в градусах/сек")]
    [SerializeField] private float rotationSpeed = 90f;

    [Tooltip("Максимальный угол вверх от начального положения")]
    [SerializeField] private float maxUpAngle = 80f;

    [Tooltip("Максимальный угол вниз от начального положения")]
    [SerializeField] private float maxDownAngle = -30f;

    private Rigidbody2D _rb;
    private float currentAngle = 0f;
    private float initialRotation;

    private void Start()
    {
        // Сохраняем начальный угол поворота
        initialRotation = _transform.eulerAngles.z;

        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleRotationInput();
        ApplyRotation();
    }

    private void HandleRotationInput()
    {
        // Получаем ввод от пользователя
        float verticalInput = _rb.linearVelocityY;

        // Рассчитываем изменение угла
        float angleChange = verticalInput * rotationSpeed * Time.deltaTime;
        currentAngle = Mathf.Clamp(currentAngle + angleChange, maxDownAngle, maxUpAngle);
    }

    private void ApplyRotation()
    {
        // Применяем поворот относительно начального положения
        _transform.rotation = Quaternion.Euler(0f, 0f, initialRotation + currentAngle);
    }
}
