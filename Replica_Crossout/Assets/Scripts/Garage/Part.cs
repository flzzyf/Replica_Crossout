using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public Vector3 size = Vector3.one;

    [HideInInspector]
    public Transform nodes;

    public GameObject prefab_node;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}
