using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject weldPointPrefab;

    GameObject[] weldPoint = new GameObject[6];

    //[HideInInspector]
    public bool[] toggle = new bool[] { true,true,true,true,true,true};

    public bool tog1;
    public bool tog2;
    public bool tog3;
    //[HideInInspector]
    public bool[] toggleLast;

    public static string[] directionName = { "上", "下", "左", "右", "前", "后" };

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

    public bool a = true;

    public void ToggleOn(int _index)
    {
        weldPoint[_index] = Instantiate(weldPointPrefab, position[_index], Quaternion.Euler(rotation[_index]), transform);
        weldPoint[_index].transform.localPosition = position[_index];
        weldPoint[_index].name = GetWeldPointName(_index);
    }

    public void ToggleOff(int _index)
    {
        DestroyImmediate(weldPoint[_index]);
    }

    string GetWeldPointName(int _index)
    {
        return "WeldPoint_" + directionName[_index];
    }


}
