using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour {

    public Camera cam;

    void Start () {
		
	}
	
	void Update ()
    {
        Vector3 lookTarget;


        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 500))
        {
            lookTarget = hit.point;
        }
        else
        {
            lookTarget = cam.transform.forward * 500;

        }

        Debug.DrawLine(cam.transform.position, lookTarget, Color.cyan, Time.deltaTime);

        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Weapon")
            {
                child.GetComponent<Turret>().Aim(lookTarget);
            }
        }



    }
}
