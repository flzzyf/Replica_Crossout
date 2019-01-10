using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour {

    public LayerMask layer;

    public bool Collided()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, Vector3.one * 1f, transform.rotation, layer);

        foreach (Collider item in colliders)
        {
            if(item.gameObject != gameObject)
            {
                Debug.Log(gameObject.name);
                return true;
            }
        }

        return false;
    }

}
