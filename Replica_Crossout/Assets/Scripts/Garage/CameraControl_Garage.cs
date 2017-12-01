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

            //限制镜头角度
            localRotation.x = Mathf.Clamp(localRotation.x, -90, 90);

            //旋转镜头
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


        //camOrigin.Translate(new Vector3(inputHorizontal, up, inputVertical) * cameraPanSpeed);

        Debug.Log(transform.up);

        //镜头上升
        if(Input.GetKey((KeyCode.Space))){
            camOrigin.Translate(transform.up * cameraPanSpeed * Time.deltaTime);
        } 
        if(Input.GetKey(KeyCode.LeftShift)){
            camOrigin.Translate(-1 * transform.up * cameraPanSpeed * Time.deltaTime);

        }


    }
}
