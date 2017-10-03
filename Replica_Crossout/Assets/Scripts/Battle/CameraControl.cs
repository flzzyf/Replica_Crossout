using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float mouseSensitivity = 3f;
    public float scrollSensitivity = 3f;

    public Vector2 cameraDistanceLimit = new Vector2(2, 6);

    public float cameraRotateSpeed = 10f;
    public float scrollSpeed = 6f;

    Transform cam;
    Transform camOrigin;

    Vector3 localRotation;
    float cameraDistance = 3f;

    void Start ()
    {
        cam = this.transform;
        camOrigin = this.transform.parent;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cameraDistance = -cam.position.z;
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

        //鼠标移动
        if(inputMouseX != 0 || inputMouseY != 0)
        {
            localRotation.x += inputMouseX * mouseSensitivity;
            localRotation.y -= inputMouseY * mouseSensitivity;

            //限制镜头角度
            localRotation.y = Mathf.Clamp(localRotation.y, -90, 90);

        }

        //旋转镜头
        Quaternion qt = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        camOrigin.rotation = Quaternion.Lerp(camOrigin.rotation, qt, Time.deltaTime * cameraRotateSpeed);

        float scrollWheelAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

        if(scrollWheelAmount != 0)
        {
            cameraDistance += scrollWheelAmount * -1;
            //限制镜头距离
            cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceLimit.x, cameraDistanceLimit.y);

        }

        cam.localPosition = new Vector3(0, 0, Mathf.Lerp(cam.localPosition.z, -cameraDistance, Time.deltaTime * scrollSpeed));

    }
}
