using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(CoinController))]
public class CoinControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var controller = target as CoinController;

        if (GUILayout.Button("collect"))
        {
            controller.Collect();
        }
    }
}
