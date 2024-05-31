using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(FarsiMaker))]
public class FarsiMakerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FarsiMaker code = (FarsiMaker)target;

        GUILayout.Space(5);

        if (GUILayout.Button("Convert", GUILayout.Height(30)))
            code.ConvertToFarsi();
    }
}
