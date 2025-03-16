using DG.Tweening;
using UnityEngine;

public class PauseViewAnimator : MonoBehaviour
{
    [Header("animation settings")]
    [SerializeField] private RectTransform _targetTransform;
    [SerializeField] private CanvasGroup _targetRenderer;
    [SerializeField] private float _showDuration;
    [SerializeField] private float _hideDuration;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _delay;

    Vector3 _endPosition;

    Tween _moveTween;
    Tween _renderTween;
    private void Start()
    {
        _endPosition = _targetTransform.localPosition;
    }
    public void AnimateShow()
    {
        _moveTween = _targetTransform
            .DOLocalMoveY(_endPosition.y, _showDuration)
            .From(_endPosition.y - _yOffset)
            .SetEase(Ease.InSine)
            .SetDelay(_delay);
        _renderTween = _targetRenderer
            .DOFade(1, _showDuration)
            .From(0)
            .SetEase(Ease.InSine)
            .SetDelay(_delay);
    }
    public void AnimateHide()
    {
        _moveTween = _targetTransform
            .DOLocalMoveY(_endPosition.y - _yOffset, _hideDuration)
            .From(_endPosition.y)
            .SetEase(Ease.InSine);
        _renderTween = _targetRenderer
            .DOFade(0, _hideDuration)
            .From(1)
            .SetEase(Ease.InSine);
    }
    private void OnDestroy()
    {
        _moveTween.Kill();
        _renderTween.Kill();
    }
}
