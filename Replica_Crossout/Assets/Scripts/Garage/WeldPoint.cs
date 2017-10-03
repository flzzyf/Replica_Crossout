using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeldPoint : MonoBehaviour {

    Transform mainPart;

    bool moving = false;

    Vector3 WeldPointOffset;

    Vector3 thisAngle;

    private void Start()
    {
        mainPart = transform.parent;

        WeldPointOffset = mainPart.position - transform.position;

        thisAngle = Util.EulerAngleNegativeFix(transform.rotation.eulerAngles);


        //Debug.Log(thisAngle);
    }

    private void OnTriggerEnter(Collider other)
    {
        //非移动中的焊点不触发碰撞事件
        if (!moving)
            return;

        if (other.CompareTag("WeldPoint"))
        {

            Vector3 otherAngle = Util.EulerAngleNegativeFix(other.transform.rotation.eulerAngles);

            //Debug.Log(Vector3.Angle(thisAngle, otherAngle));

            Debug.Log("----------");

            Debug.Log(thisAngle);
            Debug.Log(otherAngle);
            //Debug.Log(thisAngle - otherAngle);
            //Debug.Log((thisAngle - otherAngle).normalized);

            Vector3 qwe = (thisAngle - otherAngle);
            //Debug.Log(qwe.x + qwe.y + qwe.z);
            Debug.Log(qwe);
            Debug.Log(qwe.magnitude);
            //qwe = qwe.normalized;
            //Debug.Log(qwe.normalized);

            //Debug.Log("Origin: " + transform.name + ", Other: " + other.transform.name);

            //if (Vector3.Angle(thisAngle, otherAngle) == 180)
            //if (thisAngle == -otherAngle)
            //if (Mathf.Abs(qwe.x) == 180 || Mathf.Abs(qwe.y) == 180 || Mathf.Abs(qwe.z) == 180)
            //if (qwe == Vector3.forward || qwe == Vector3.back || qwe == Vector3.left || qwe == Vector3.right || qwe == Vector3.up || qwe == Vector3.down)
            if (qwe.magnitude == 180)
            //if (qwe.x + qwe.y + qwe.z == 1)
            {
                mainPart.GetComponent<Part_Move>().StopMoving();

                mainPart.position = other.transform.position + WeldPointOffset;



                //Debug.Log((otherAngle - thisAngle));
                //Debug.Log(thisAngle.);




            }

            //Debug.Log(Util.EulerAngleNegativeFix(transform.rotation.eulerAngles));
            //Debug.Log(Util.EulerAngleNegativeFix(other.transform.rotation.eulerAngles));
        }
    }

    public void SetMoving(bool _moving)
    {
        moving = _moving;
    }
}
