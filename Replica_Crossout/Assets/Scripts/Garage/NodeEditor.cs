using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Node))]
public class NodeEditor : Editor
{
    //检视器更改
    public override void OnInspectorGUI()
    {
        Node node = (Node)target;

        base.OnInspectorGUI();
        //DrawDefaultInspector();

        GUILayout.Label("设置焊点位置:");

        //Debug.Log(node.toggle[0]);

        node.toggle[0] = EditorGUILayout.Toggle(node.toggle[0]);


        for (int i = 0; i < 3; i++)
                {
                    GUILayout.BeginHorizontal();
                    node.toggle[2 * i] = EditorGUILayout.Toggle(Node.directionName[2 * i], node.toggle[2 * i]);
                    node.toggle[2 * i + 1] = EditorGUILayout.Toggle(Node.directionName[2 * i + 1], node.toggle[2 * i + 1]);
                    GUILayout.EndHorizontal();
                }
    }
}
