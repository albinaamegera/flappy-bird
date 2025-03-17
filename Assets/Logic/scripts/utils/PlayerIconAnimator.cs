using DG.Tweening;
using UnityEngine;

public class PlayerIconAnimator : MonoBehaviour
{
    [Header("animation settings")]
    [SerializeField] private RectTransform _transform;
    [SerializeField] private Vector2 _endValue;
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease;

    private Vector3 _startScale;
    Sequence _sequence;
    private void Awake()
    {
        _startScale = _transform.localScale;
    }
    public void Animate()
    {
        _sequence = DOTween.Sequence();
        _sequence
            .Append(_transform.DOScale(_endValue, _duration))
            .Append(_transform.DOScale(_startScale, _duration))
            .SetLoops(-1)
            .SetEase(_ease);
    }
    public void StopAnimate()
    {
        _sequence.Kill();
    }
}
