using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePartManager : MonoBehaviour
{
    Camera cam;

    Transform target;
    Transform movingObj;

    public LayerMask layer_part;
    public LayerMask layer_collider;

    public float maxDistance = 15f;

    RaycastHit hit;

    void Start()
    {
        cam = Camera.main;
    }

    void Update ()
    {
        //鼠标不在移动，结束
        //if (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0)
            //return;

        //如果没有正在移动的物体
        if (movingObj == null)
        {
            //从镜头前方获取高亮物体
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance, layer_part))
            {
                target = hit.transform;

                //高亮所选
                //target.GetComponentInChildren<Renderer>().materials[1].SetFloat("_OutlineWidth", 0.2f);

                //鼠标左键点击，选中该物体
                if (Input.GetMouseButtonDown(0))
                {
                    movingObj = target;

                    movingObj.GetComponent<Node>().OnBecomeMoving();
                }
            }
            else
            {
                target = null;
            }
        }
        else
        {
            //正在移动物体

            //移动该物体到镜头前方的可放置处
            if (Physics.BoxCast(cam.transform.position, Vector3.one / 2, cam.transform.forward, out hit, Quaternion.identity, maxDistance, layer_collider))
            {
                //if(hit.transform != movingObj)
                    movingObj.position = hit.point + hit.normal / 2;
            }

            //鼠标右键点击，取消移动物体
            if (Input.GetMouseButtonDown(1))
            {
                movingObj.GetComponent<Node>().OnStopMoving();

                movingObj = null;
            }
        }
    }
}
