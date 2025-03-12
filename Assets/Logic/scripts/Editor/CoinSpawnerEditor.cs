using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(CoinSpawner))]
public class CoinSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var spawner = target as CoinSpawner;

        if(GUILayout.Button("spawn"))
        {
            spawner.Spawn();
        }
    }
}
