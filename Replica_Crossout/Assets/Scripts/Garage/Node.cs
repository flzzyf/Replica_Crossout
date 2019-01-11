using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject weldPointPrefab;

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

    new Collider collider;

    //特定位置有焊点
    public bool[] hasWeldPoint = new bool[] { false, false, false, false, false, false};
    //焊点物体
    GameObject[] weldPoints = new GameObject[6];
    Transform weldPointParent;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    public void CreateWeldPoint(int _index)
    {
        if (weldPointParent == null)
        {
            weldPointParent = new GameObject("WelpPoints").transform;
            weldPointParent.parent = transform;
        }

        weldPoints[_index] = Instantiate(weldPointPrefab, transform.position + position[_index], Quaternion.Euler(rotation[_index]), weldPointParent);
    }

    public void RemoveWeldPoint(int _index)
    {
        DestroyImmediate(weldPoints[_index]);
    }

    public void OnBecomeMoving()
    {
        collider.enabled = false;
    }

    public void OnStopMoving()
    {
        collider.enabled = true;
    }

}
