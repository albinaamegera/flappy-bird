using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(LanguageSwitcher))]
public class LanguageSwitcherEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var switcher = target as LanguageSwitcher;

        if (GUILayout.Button("switch"))
        {
            switcher.ChangeLocale();
        }
    }
}
