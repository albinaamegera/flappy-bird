using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float duration = 3f;
    [SerializeField] private bool autoStart = false;
    [SerializeField] private bool repeat = false;

    [Header("Events")]
    public UnityEvent OnTimerStart;
    public UnityEvent OnTimerComplete;

    private float _timeLeft;
    private bool _isRunning = false;

    public bool IsRunning => _isRunning;
    public float TimeLeft => _timeLeft;
    public float Progress => 1 - (_timeLeft / duration);

    private void Start()
    {
        if (autoStart) StartTimer();
    }

    private void Update()
    {
        if (!_isRunning) return;

        _timeLeft -= Time.deltaTime;

        if (_timeLeft <= 0)
        {
            CompleteTimer();
        }
    }

    public void StartTimer()
    {
        _timeLeft = duration;
        _isRunning = true;
        OnTimerStart?.Invoke();
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public void ResetTimer()
    {
        _timeLeft = duration;
        _isRunning = false;
    }

    private void CompleteTimer()
    {
        _isRunning = false;
        OnTimerComplete?.Invoke();

        if (repeat) StartTimer();
    }
}
