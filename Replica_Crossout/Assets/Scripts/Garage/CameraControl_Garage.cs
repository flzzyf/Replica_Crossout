using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl_Garage : MonoBehaviour {

    public float mouseSensitivity = 3f;
    public float scrollSensitivity = 3f;

    public Vector2 cameraDistanceLimit = new Vector2(2, 6);

    public float cameraRotateSpeed = 10f;
    public float scrollSpeed = 6f;
    public float cameraPanSpeed = 0.5f;

    Transform cam;
    Transform camOrigin;

    Vector3 localRotation;
    float cameraDistance = 0f;

    void Start ()
    {
        cam = this.transform;
        camOrigin = this.transform.parent;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        localRotation = camOrigin.rotation.eulerAngles;

        //cameraDistance = -cam.position.z;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void LateUpdate ()
    {
        float inputMouseX = Input.GetAxis("Mouse X");
        float inputMouseY = Input.GetAxis("Mouse Y");

        //Debug.Log(inputMouseX);
        //Debug.Log(inputMouseY);

        //鼠标移动
        if (inputMouseX != 0 || inputMouseY != 0)
        {
            //水平y，竖直x
            localRotation.y += inputMouseX * mouseSensitivity;
            localRotation.x -= inputMouseY * mouseSensitivity;

            //Debug.Log(localRotation);
            //Debug.Log(Util.EulerAngleNegativeFix(localRotation));

            //localRotation = Util.EulerAngleNegativeFix(localRotation);

            //限制镜头角度
            localRotation.x = Mathf.Clamp(localRotation.x, -90, 90);

            //旋转镜头
            //Vector3 rotation = new Vector3(Util.EulerAngleNegativeFix(localRotation.y), -localRotation.x, 0);
            //Vector3 rotation = new Vector3(localRotation.x, localRotation.y, 0);
            //Quaternion qt = Quaternion.Euler(rotation);
            //camOrigin.rotation = Quaternion.Lerp(camOrigin.rotation, qt, Time.deltaTime * cameraRotateSpeed);

            //camOrigin.rotation = qt;
            //rotation = new Vector3(localRotation.y, localRotation.x, 0);
            //camOrigin.rotation = Quaternion.Euler(rotation);
            camOrigin.rotation = Quaternion.Euler(localRotation);

        }



        float scrollWheelAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

        if(scrollWheelAmount != 0)
        {
            cameraDistance += scrollWheelAmount * -1;
            //限制镜头距离
            cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceLimit.x, cameraDistanceLimit.y);

        }

        //cam.localPosition = new Vector3(0, 0, Mathf.Lerp(cam.localPosition.z, -cameraDistance, Time.deltaTime * scrollSpeed));
        cam.localPosition = new Vector3(0, 0, -cameraDistance);

        //WASD
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        float up = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            up = 1;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            up = -1;
        }

        camOrigin.Translate(new Vector3(inputHorizontal, up, inputVertical) * cameraPanSpeed);



    }
}
