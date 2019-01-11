using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Node))]
public class NodeEditor : Editor
{
    Node node;

    public static Vector3[] position = {
        new Vector3(0, 0.5f, 0),
        new Vector3(0, -0.5f, 0),
        new Vector3(0, 0, -0.5f),
        new Vector3(0, 0, 0.5f),
        new Vector3(0.5f, 0, 0),
        new Vector3(-0.5f, 0, 0)
    };
    static Vector3[] rotation ={
        new Vector3(0, 0, 0),
        new Vector3(0, 0, 180),
        new Vector3(-90, 0, 0),
        new Vector3(90, 0, 0),
        new Vector3(0, 0, -90),
        new Vector3(0, 0, 90)
    };
    public static string[] directionName = { "上", "下", "左", "右", "前", "后" };

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
            node.hasWeldPoint[i] = EditorGUILayout.Toggle(directionName[i], node.hasWeldPoint[i]);
            if(EditorGUI.EndChangeCheck())
            {
                ToggleWeldPoint(i);
            }

            if (i % 2 != 0)
                GUILayout.EndHorizontal();
        }

        if (GUI.changed)
            EditorUtility.SetDirty(node);

        serializedObject.ApplyModifiedProperties();
    }

    //切换生成焊点
    void ToggleWeldPoint(int _index)
    {
        if (node.hasWeldPoint[_index])
        {
            CreateWeldPoint(_index);
        }
        else
        {
            RemoveWeldPoint(_index);
        }

        EditorUtility.SetDirty(node);
    }
    //创建焊点
    public void CreateWeldPoint(int _index)
    {
        Transform weldPointParent = node.weldPointParent;
        if (node.weldPointParent == null)
        {
            weldPointParent = new GameObject("WelpPoints").transform;
            weldPointParent.parent = node.transform;
            weldPointParent.localPosition = Vector3.zero;
        }

        node.weldPoints[_index] = Instantiate(node.weldPointPrefab, node.transform.position + position[_index], Quaternion.Euler(rotation[_index]), weldPointParent);
        //PrefabUtility.ConnectGameObjectToPrefab(node.weldPoints[_index], node.weldPointPrefab);

        //设置当前场景需要保存
        EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
    }
    //移除焊点
    public void RemoveWeldPoint(int _index)
    {
        DestroyImmediate(node.weldPoints[_index]);
    }
}
