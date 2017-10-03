using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node : MonoBehaviour {

    public GameObject weldPointPrefab;

    GameObject[] weldPoint = new GameObject[6];

    [HideInInspector]
    public bool[] toggle = new bool[6];

    string[] directionName = { "上", "下", "左", "右", "前", "后" };

    public bool alreadyInit = false;

    static Vector3[] position;
    static Vector3[] rotation;

    public static void StaticInit()
    {
        //Debug.Log("Static"); 

        position = new Vector3[6];
        rotation = new Vector3[6];

        position[0] = new Vector3(0, 0.5f, 0);
        rotation[0] = new Vector3(0, 0, 0);

        position[1] = new Vector3(0, -0.5f, 0);
        rotation[1] = new Vector3(0, 0, 180);

        position[2] = new Vector3(0, 0, -0.5f);
        rotation[2] = new Vector3(-90, 0, 0);

        position[3] = new Vector3(0, 0, 0.5f);
        rotation[3] = new Vector3(90, 0, 0);

        position[4] = new Vector3(0.5f, 0, 0);
        rotation[4] = new Vector3(0, 0, -90);

        position[5] = new Vector3(-0.5f, 0, 0);
        rotation[5] = new Vector3(0, 0, 90);
    }

    public void Init()
    {
        //Debug.Log("Init");

        toggle = new bool[6];

        alreadyInit = true;

        foreach (Transform child in transform)
        {
            for (int i = 0; i < 6; i++)
            {
                if(child.name == GetWeldPointName(i))
                {
                    toggle[i] = true;
                    weldPoint[i] = child.gameObject;
                }
            }
        }

    }

    public void ToggleOn(int _index)
    {
        toggle[_index] = true;

        //weldPoint[_index] = Instantiate(weldPointPrefab, weldPointPos[_index].position, Quaternion.Euler(weldPointPos[_index].rotation), transform);
        weldPoint[_index] = Instantiate(weldPointPrefab, position[_index], Quaternion.Euler(rotation[_index]), transform);
        weldPoint[_index].transform.localPosition = position[_index];
        weldPoint[_index].name = GetWeldPointName(_index);
    }

    public void ToggleOff(int _index)
    {
        toggle[_index] = false;

        DestroyImmediate(weldPoint[_index]);
    }

    string GetWeldPointName(int _index)
    {
        return "WeldPoint_" + directionName[_index];
    }
}
