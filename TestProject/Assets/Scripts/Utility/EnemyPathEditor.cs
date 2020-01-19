using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyPath))]
public class EnemyPathEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EnemyPath script = (EnemyPath)target;

        if (GUILayout.Button("Generate Path"))
        {
            script.GeneratePath();
        }
    }
}
