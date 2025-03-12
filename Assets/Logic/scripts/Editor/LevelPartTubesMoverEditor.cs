using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(LevelPartsTubesMover))]
public class LevelPartTubesMoverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var mover = target as LevelPartsTubesMover;

        if (GUILayout.Button("shift"))
        {
            mover.Shift();
        }
    }
}
