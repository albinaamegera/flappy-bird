using DG.Tweening;
using TMPro;
using UnityEngine;
using System.Collections;

public class CountDownViewController : MonoBehaviour
{
    [Header("count down settings")]
    [SerializeField] private TMP_Text _text;
    [SerializeField] private RectTransform _rect;
    [SerializeField] private int _seconds;
    private int _currentSeconds;

    [Header("animation settings")]
    [SerializeField] private float _duration = 1f;
    [SerializeField] private float _normalScale;
    [SerializeField] private float _minScale;
    [SerializeField] private Ease _ease;

    private Tween _tween;

    private EventListener<OnLevelContinueEvent> _onLevelContinueEventListener = new();

    private void Awake()
    {
        _onLevelContinueEventListener.Add(() => gameObject.SetActive(true));
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        _currentSeconds = _seconds;
        _tween = _rect.DOScale(_minScale, _duration).From(_normalScale).SetEase(_ease).SetLoops(_seconds);
        StartCoroutine(StartTimer());
    }
    private IEnumerator StartTimer()
    {
        while (_currentSeconds > 0)
        {
            _text.text = _currentSeconds.ToString();

            yield return new WaitForSeconds(_duration);

            _currentSeconds--;
        }

        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        _tween.Kill();
    }
}
