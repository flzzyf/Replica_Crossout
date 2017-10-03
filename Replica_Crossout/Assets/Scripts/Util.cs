using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {

    //把欧拉角限制在-180到180 
    public static float EulerAngleNegativeFix(float angle)
    {
        //超过180度就减360变成负数
        angle = (angle > 180) ? angle - 360 : angle;
        return angle;

    }

    public static Vector3 EulerAngleNegativeFix(Vector3 angle)
    {
        //超过180度就减360变成负数
        angle.x = (angle.x > 180) ? angle.x - 360 : angle.x;
        angle.y = (angle.y > 180) ? angle.y - 360 : angle.y;
        angle.z = (angle.z > 180) ? angle.z - 360 : angle.z;
        return angle;

    }
}
