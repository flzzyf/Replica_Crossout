using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePartManager : MonoBehaviour {

    Camera cam;

    Transform target;
    Transform movingObj;

    public LayerMask layer;

    public float maxDistance = 15f;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update ()
    {
        RaycastHit hit;

        float inputMouseX = Input.GetAxis("Mouse X");
        float inputMouseY = Input.GetAxis("Mouse Y");

        //鼠标在移动
        if (inputMouseX != 0 || inputMouseY != 0)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 500, layer))
            {
                target = hit.transform;
                //Debug.Log("hit");

                //高亮所选
                //target.GetComponentInChildren<Renderer>().materials[1].SetFloat("_OutlineWidth", 0.2f);

            }
            else
            {
                //BUG:连续进入两物体
                target = null;
            }

            if (movingObj != null)
            {
                //if(movingObj.GetComponent<Part>().collided == false)
                
                    movingObj.transform.position = cam.transform.position;

                StopAllCoroutines();
                Move();



            }
        }


        //鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            if(movingObj == null)
            {
                if(target != null)
                {
                    movingObj = target;
                }
            }
            else
            {
                movingObj = null;

            }
        }


    }


    void Move()
    {
        while (movingObj.GetComponent<Part>().Collided() == false && Vector3.Distance(movingObj.position, cam.transform.position) < maxDistance)
        {

            movingObj.Translate(cam.transform.forward * 1f);

            //movingObj.gameObject.GetComponent<Collider>().    

            //movingObj.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            //movingObj.gameObject.GetComponent<Rigidbody>().AddForce(cam.transform.forward * 0.5f);


        }
    }
}
