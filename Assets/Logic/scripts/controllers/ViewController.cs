using UnityEngine;
using UnityEngine.Events;

public abstract class ViewController : MonoBehaviour, IViewController
{
    [Header("default")]
    [SerializeField] protected CanvasGroup _current;
    [Header("callbacks")]
    [SerializeField] protected UnityEvent _onHide;
    [SerializeField] protected UnityEvent _onShow;
    public virtual void Hide()
    {
        _current.interactable = false;
        _onHide.Invoke();
    }
    public virtual void Show()
    {
        _current.interactable = true;
        _onShow.Invoke();
    }
}
