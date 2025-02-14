using UnityEngine;

public class InfiniteBackgroundManager : InfiniteLevelManager
{
    protected override void CheckCameraBorders()
    {
        if (_camera.transform.position.x - _cameraHalfWidth > _partsOnLevel[1].transform.position.x)
        {
            MoveLastToFirst();
        }
    }
}
