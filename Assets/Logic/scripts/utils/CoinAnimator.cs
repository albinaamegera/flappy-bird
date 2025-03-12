using DG.Tweening;
using UnityEngine;

public class CoinAnimator : MonoBehaviour
{
    [Header("referenses")]
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Transform _transform;

    [Header("animation settings")]
    [SerializeField] private float _fadeDuration;
    [SerializeField] private float _moveUpDuration;
    [SerializeField] private float _endYValue;

    public void Animate()
    {
        _transform.DOLocalMoveY(_endYValue, _moveUpDuration).From(0).SetEase(Ease.Linear);
        _renderer.DOFade(0, _fadeDuration).From(1).SetEase(Ease.Linear);
    }
}
