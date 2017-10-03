using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject turretPrefab;

	void Start ()
    {
        Instantiate(turretPrefab, transform.position, transform.rotation, transform);
        Instantiate(turretPrefab, transform.position + new Vector3(1, 0, 0), transform.rotation, transform);
        Instantiate(turretPrefab, transform.position + new Vector3(1, 0, 1), transform.rotation, transform);
    }
	
	void Update ()
    {
        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("Fire");
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == "Weapon")
                {
                    child.GetComponent<Turret>().Fire();
                }
            }
        }
    }
}
