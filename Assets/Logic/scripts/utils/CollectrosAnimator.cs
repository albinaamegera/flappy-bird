using DG.Tweening;
using UnityEngine;

public class CollectrosAnimator : MonoBehaviour
{
    [Header("animation settings")]
    [Tooltip("target rect tracform to animate")]
    [SerializeField] private RectTransform _target;

    [Tooltip("tween animation punch")]
    [SerializeField] private Vector3 _animationPunch;

    [Tooltip("duration of animation")]
    [SerializeField] private float _duration;

    [Tooltip("vibrato")]
    [SerializeField] private int _vibrato = 10;

    [Tooltip("elasticity")]
    [Range(0, 1)]
    [SerializeField] private float _elasticity = 1;

    public void Animate()
    {
        _target.DOPunchScale(_animationPunch, _duration, _vibrato, _elasticity);
    }
}
