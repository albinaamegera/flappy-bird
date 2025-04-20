using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(CanvasGroup))]
public abstract class ViewController : MonoBehaviour, IViewController
{
    [Header("default")]
    [SerializeField] protected CanvasGroup _current;
    [SerializeField] protected bool _changeAlphaOnSelect = false;
    [SerializeField] protected bool _canBeInteractable = false; 
    [Header("callbacks")]
    [SerializeField] protected UnityEvent _onHide;
    [SerializeField] protected UnityEvent _onShow;
    public virtual void Hide()
    {
        if (_changeAlphaOnSelect)
            _current.alpha = 0;
        if (_canBeInteractable)
            _current.interactable = false;
        _current.blocksRaycasts = false;
        _onHide.Invoke();

        gameObject.SetActive(false);
    }
    public virtual void Show()
    {
        if (_changeAlphaOnSelect)
            _current.alpha = 1;
        if (_canBeInteractable)
            _current.interactable = true;
        _current.blocksRaycasts = true;
        _onShow.Invoke();

        gameObject.SetActive(true);
    }
}
