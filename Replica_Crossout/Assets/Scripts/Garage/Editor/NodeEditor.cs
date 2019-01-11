using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Node))]
public class NodeEditor : Editor
{
    Node node;

    //检视器更改
    public override void OnInspectorGUI()
    {
        node = (Node)target;

        base.OnInspectorGUI();

        GUILayout.Label("设置焊点位置:");

        for (int i = 0; i < 6; i++)
        {
            //i为偶数begin，奇数end
            if(i % 2 == 0)
                GUILayout.BeginHorizontal();

            //值改变
            EditorGUI.BeginChangeCheck();
            node.hasWeldPoint[i] = EditorGUILayout.Toggle(Node.directionName[i], node.hasWeldPoint[i]);
            if(EditorGUI.EndChangeCheck())
            {
                ToggleWeldPoint(i);
            }

            if (i % 2 != 0)
                GUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();
    }

    //切换生成焊点
    void ToggleWeldPoint(int _index)
    {
        if (node.hasWeldPoint[_index])
        {
            node.CreateWeldPoint(_index);
        }
        else
        {
            node.RemoveWeldPoint(_index);
        }
    }
}
