using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WRD))]
public class WRDEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WRD code = (WRD)target;

        GUILayout.Space(5);
        if (GUILayout.Button("Distribute", GUILayout.Height(30)))
            code.Execute();
    }
}
