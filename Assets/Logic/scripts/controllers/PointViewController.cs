using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PointViewController : MonoBehaviour
{
    [Header("ui references")]
    [SerializeField] private TMP_Text _text;

    [Header("callbacks")]
    [SerializeField] private UnityEvent _onViewUpdated;

    private ScoreCounter _counter;

    public void Initialize(ScoreCounter counter)
    {
        _counter = counter;
        _counter.OnScoreChanged += UpdateView;
    }
    private void UpdateView(int value)
    {
        Debug.Log($"point view updated {value}");
        _text.text = value.ToString();
        _onViewUpdated.Invoke();
    }
}
