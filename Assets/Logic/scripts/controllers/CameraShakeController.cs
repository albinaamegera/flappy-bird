using UnityEngine;
using System.Collections;

public class CameraShakeController : MonoBehaviour
{
    [Header("Основные настройки")]
    [Tooltip("Длительность эффекта в секундах")]
    public float duration = 0.5f;

    [Tooltip("Максимальное смещение по осям X/Y")]
    public float strength = 0.1f;

    [Tooltip("Кастомное смещение по осям X/Y")]
    public float customStrength = -1;

    [Tooltip("Максимальное вращение по оси Z (градусы)")]
    public float rotationalStrength = 2f;

    [Header("Оси воздействия")]
    [Tooltip("Использовать горизонтальную тряску (X)")]
    public bool shakeX = true;

    [Tooltip("Использовать вертикальную тряску (Y)")]
    public bool shakeY = true;

    [Tooltip("Использовать вращательную тряску (Z-rotation)")]
    public bool allowRotation = true;

    [Header("Затухание")]
    [Tooltip("Кривая уменьшения интенсивности со временем")]
    public AnimationCurve dampCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);

    private Vector3 originalPos;
    private Quaternion originalRot;
    private Coroutine shakeRoutine;

    public void TriggerShake()
    {
        if (shakeRoutine != null) StopCoroutine(shakeRoutine);
        shakeRoutine = StartCoroutine(Shake(customStrength >= 0 ? customStrength : strength));
    }

    private IEnumerator Shake(float currentStrength)
    {
        originalPos = transform.localPosition;
        originalRot = transform.localRotation;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float percentComplete = elapsed / duration;
            float damper = dampCurve.Evaluate(percentComplete);

            // Позиционная тряска
            float xOffset = shakeX ? Random.Range(-1f, 1f) * currentStrength * damper : 0;
            float yOffset = shakeY ? Random.Range(-1f, 1f) * currentStrength * damper : 0;
            transform.localPosition = originalPos + new Vector3(xOffset, yOffset, 0);

            // Вращательная тряска
            if (allowRotation)
            {
                float rotOffset = Random.Range(-1f, 1f) * rotationalStrength * damper;
                transform.localRotation = originalRot * Quaternion.Euler(0, 0, rotOffset);
            }

            yield return null;
        }

        transform.localPosition = originalPos;
        transform.localRotation = originalRot;
    }
}