using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _onCollected;
    [SerializeField] private Transform _transform;
    [Header("collect animation")]
    [SerializeField] private float _yOffset = 1f;
    [SerializeField] private float _duration = 1f;
    [SerializeField] private float _yRotationAngle = 180f;

    SpriteRenderer _renderer;
    Sequence _animation;
    Tween _rotation;

    private void Awake()
    {
        _renderer = _transform.GetComponent<SpriteRenderer>();
        _rotation = _transform
                .DORotate(new Vector3(0f, _yRotationAngle, 0f), _duration, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        _rotation.TogglePause();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collect();
        }
    }
    public void Restart()
    {
        KillAnimationIfActive();

        gameObject.SetActive(true);
        _transform.localPosition = Vector3.zero;
        _transform.localRotation = Quaternion.Euler(Vector3.zero);
        _renderer.color = Color.white;

        _rotation.TogglePause();

        Debug.Log("idle animation");
    }
    public void Collect()
    {
        GameManager.Instance.CollectCoin();
        _onCollected.Invoke();
        OnCollectAnimation();
    }
    public bool IfAnimation() => _animation != null && _animation.IsActive();
    private void KillAnimationIfActive()
    {
        if (IfAnimation())
        {
            _animation.Kill();
        }
    }
    void OnCollectAnimation()
    {
        _rotation.TogglePause();
        _animation = DOTween.Sequence();

        _animation
            .Join(_transform.DORotate(new Vector3(0f, _yRotationAngle, 0f), _duration, RotateMode.FastBeyond360).SetEase(Ease.Linear))
            .Join(_transform.DOMoveY(_yOffset, _duration))
            .Join(_renderer.DOFade(0, _duration));
        _animation.OnComplete(delegate { gameObject.SetActive(false); });
    }
}
