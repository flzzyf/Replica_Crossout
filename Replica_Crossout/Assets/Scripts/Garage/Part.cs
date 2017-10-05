using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour {

    public bool collided = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        collided = true;

    }

    private void OnTriggerExit(Collider other)
    {
        collided = false;

    }


}
