using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Node))]
public class NodeEditor : Editor
{
    //string[] directionName = { "上", "下", "左", "右", "前", "后" };

    Node node;

    //创建一个新检视器时
    private void OnEnable()
    {
        Debug.Log("OnEnable()");

        node = (Node)target;

    }
    //检视器更改
    public override void OnInspectorGUI()
    {
        //Debug.Log("OnInspectorGUI()");

        //toggle = node.toggle;

        //toggleLast = node.toggleLast;

        base.OnInspectorGUI();
        //DrawDefaultInspector();

        GUILayout.Label("设置焊点位置:");

        node.tog1 = EditorGUILayout.Toggle(node.tog1);
        node.tog2 = EditorGUILayout.Toggle(node.tog2);


        //Debug.Log(node.toggle[0]);

        node.toggle[0] = EditorGUILayout.Toggle(node.toggle[0]);


        for (int i = 0; i < 3; i++)
                {
                    GUILayout.BeginHorizontal();
                    node.toggle[2 * i] = EditorGUILayout.Toggle(Node.directionName[2 * i], node.toggle[2 * i]);
                    node.toggle[2 * i + 1] = EditorGUILayout.Toggle(Node.directionName[2 * i + 1], node.toggle[2 * i + 1]);
                    GUILayout.EndHorizontal();
                }

        /*
        //遍历所有切换按钮
        for (int i = 0; i < toggle.Length; i++)
        {
            if (toggle[i] != toggleLast[i])
            {
                toggleLast[i] = !toggleLast[i];
                if (toggleLast[i])
                {
                    //Debug.Log("选中按钮，序号：" + i);

                    node.ToggleOn(i);
                }
                else
                {
                    //Debug.Log("取消选中按钮，序号：" + i);

                    node.ToggleOff(i);
                }
            }
        }*/

    }


}
