using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Lemon))]
public class LemonEditor : Editor
{

    Lemon lemon;

    private void OnEnable()
    {
        //Debug.Log("OnEnable()");

        lemon = (Lemon)target;

    }

    //检视器更改
    public override void OnInspectorGUI()
    {
        //Debug.Log("OnInspectorGUI()");

        base.OnInspectorGUI();

        lemon.a = EditorGUILayout.Toggle(lemon.a);

        if (GUILayout.Button("Generate Color")){
            Debug.Log(("Pressed"));
        }

        //把其间内容放同一行
        GUILayout.BeginHorizontal();
        GUILayout.EndHorizontal();

    }

}
