using UnityEngine;

[RequireComponent(typeof(CameraFollowController))]
public class CameraController : MonoBehaviour
{
    private CameraFollowController _followController;
    private CameraShake2D _cameraShaker;

    // event listeners
    private EventListener<OnPlayerTransform> _onOlayerTransformEventListener = new();
    private EventListener<OnLevelExitEvent> _onLevelExitEventListener = new();
    private EventListener<OnPlayerCollision> _onPlayerCollisionEvent = new();
    private void Awake()
    {
        _followController = GetComponent<CameraFollowController>();
        _cameraShaker = GetComponent<CameraShake2D>();
        _onOlayerTransformEventListener.Add(e => SetTarget(e.transform));
        _onLevelExitEventListener.Add(SetDefaultPosition);
        _onPlayerCollisionEvent.Add(TriggerShake);
    }
    private void SetTarget(Transform target) => _followController.SetTarget(target);
    private void SetDefaultPosition() => _followController.ResetPosition();
    private void TriggerShake()
    {
        if (_cameraShaker == null)
        {
            Debug.LogWarning("camera shaker is null");
            return;
        }
        _cameraShaker.TriggerShake();
    }
}
