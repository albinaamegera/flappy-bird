using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var manager = target as GameManager;

        if (GUILayout.Button("start level"))
        {
            manager.StartLevel();
        }
        if (GUILayout.Button("restart level"))
        {
            manager.RestartLevel();
        }
        if (GUILayout.Button("end level"))
        {
            manager.EndLevel();
        }
    }
}
