using UnityEngine;

[RequireComponent(typeof(CameraFollowController))]
public class CameraController : MonoBehaviour
{
    private CameraFollowController _followController;
    // camera shake

    // event listeners
    private EventListener<OnPlayerTransform> _onOlayerTransformEventListener = new();
    private EventListener<OnLevelExitEvent> _onLevelExitEventListener = new();
    // event listener for camera shake
    private void Awake()
    {
        _followController = GetComponent<CameraFollowController>();
        _onOlayerTransformEventListener.Add(e => SetTarget(e.transform));
        _onLevelExitEventListener.Add(SetDefaultPosition);
    }
    private void SetTarget(Transform target) => _followController.SetTarget(target);
    private void SetDefaultPosition() => _followController.ResetPosition();
    // camera shake method
}
