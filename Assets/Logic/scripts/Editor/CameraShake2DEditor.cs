using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(CameraShake2D))]
public class CameraShake2DEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var shaker = target as CameraShake2D;

        if (GUILayout.Button("shake"))
        {
            shaker.TriggerShake();
        }
    }
}
