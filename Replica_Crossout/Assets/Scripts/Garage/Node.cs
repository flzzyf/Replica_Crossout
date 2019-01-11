using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject weldPointPrefab;

    Collider boxCollider;

    //特定位置有焊点
    public bool[] hasWeldPoint = new bool[] { false, false, false, false, false, false};
    //焊点物体
    [HideInInspector]
    public GameObject[] weldPoints = new GameObject[6];
    [HideInInspector]
    public Transform weldPointParent;

    void Start()
    {
        boxCollider = GetComponent<Collider>();
    }

    public void OnBecomeMoving()
    {
        boxCollider.enabled = false;
    }

    public void OnStopMoving()
    {
        boxCollider.enabled = true;
    }

}
