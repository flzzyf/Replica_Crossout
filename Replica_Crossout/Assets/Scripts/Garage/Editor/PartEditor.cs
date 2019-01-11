using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Part))]
public class PartEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Part main = (Part)target;

        base.OnInspectorGUI();

        if(GUILayout.Button("更新节点"))
        {
            if (main.nodes != null)
                DestroyImmediate(main.nodes.gameObject);

            main.nodes = new GameObject("Nodes").transform;
            main.nodes.parent = main.transform;

            Vector3 origin = main.transform.position - new Vector3(main.size.x - 1, main.size.y - 1, main.size.z - 1) / 2;
            for (int i = 0; i < main.size.x; i++)
                for (int j = 0; j < main.size.y; j++)
                    for (int k = 0; k < main.size.z; k++)
                    {
                        GameObject go = Instantiate(main.prefab_node, origin + new Vector3(i, j, k), Quaternion.identity, main.nodes);
                        EditorUtility.SetDirty(go);

                    }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
