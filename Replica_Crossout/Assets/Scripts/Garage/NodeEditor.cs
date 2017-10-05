using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Node))]
public class NodeEditor : Editor
{

    bool[] toggle = new bool[6];
    bool[] toggleLast = new bool[6];

    string[] directionName = { "上", "下", "左", "右", "前", "后" };

    Node node;

    static bool alreadyInit = false;

    //创建一个新检视器时
    private void OnEnable()
    {
        //Debug.Log("New node editor enable");

        node = (Node)target;

        if (alreadyInit == false)
        {
            alreadyInit = true;

            Node.StaticInit();

            //node.Init();
        }

        if (node.alreadyInit == false)
        {

            node.Init();
        }

        for (int i = 0; i < toggle.Length; i++)
        {
            toggle[i] = node.toggle[i];
            toggleLast[i] = node.toggle[i];
        }

    }
    //检视器更改
    public override void OnInspectorGUI()
    {
        //Debug.Log(node.name);

        base.OnInspectorGUI();
        //DrawDefaultInspector();

        serializedObject.Update();
        serializedObject.ApplyModifiedProperties();
        
        GUILayout.Label("设置焊点位置:");

        //更新当前勾选
        //for (int i = 0; i < toggle.Length; i++)
        //{
        //    toggle[i] = node.toggle[i];
        //    toggleLast[i] = node.toggle[i];
        //}

        //return;

        for (int i = 0; i < 3; i++)
        {
            GUILayout.BeginHorizontal();
            toggle[2 * i] = EditorGUILayout.Toggle(directionName[2 * i], toggle[2 * i]);
            toggle[2 * i + 1] = EditorGUILayout.Toggle(directionName[2 * i + 1], toggle[2 * i + 1]);
            GUILayout.EndHorizontal();
        }


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
        }

    }


}
