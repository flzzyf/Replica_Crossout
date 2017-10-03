using System.Collections;
using UnityEngine;

public class Part_Move : MonoBehaviour
{
    LayerMask mask;

    Camera cam;

    Rigidbody rb;

    bool moving = false;

    public Material mat;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        mask = LayerMask.NameToLayer("Item");


    }

    private IEnumerator OnMouseEnter()
    {
        //GetComponent<MeshRenderer>().materials.

        //Debug.Log(transform.name);

        GameManager.instance.playerHighlightTarget = transform.gameObject;

        yield return new WaitForFixedUpdate();

    }

    private IEnumerator OnMouseExit()
    {
        GameManager.instance.playerHighlightTarget = null;

        yield return new WaitForFixedUpdate();

    }

    //物体被点击
    IEnumerator OnMouseDown()
    {
        //Debug.Log("click object name is " + transform.name);

        Vector3 curScreenSpace;
        Vector3 CurPosition;

        //while还按着鼠标
        while (Input.GetMouseButton(0))
        {
            float inputMouseX = Input.GetAxis("Mouse X");
            float inputMouseY = Input.GetAxis("Mouse Y");

            if (inputMouseX != 0 || inputMouseY != 0)
            {
                StartMoving();

                //获取鼠标屏幕位置
                curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3);
                //获取鼠标三维位置
                CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace);
                //将物体移动到鼠标三维位置
                transform.position = CurPosition;

            }
            //获取鼠标屏幕位置
            curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            //获取鼠标三维位置
            CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace);

            GetComponent<Rigidbody>().AddForce(cam.transform.forward * 100);

            //Debug.DrawRay(cam.transform.position, CurPosition.normalized, Color.green, Time.deltaTime);
            Debug.DrawLine(cam.transform.position, CurPosition.normalized, Color.cyan, Time.deltaTime);
            //Debug.DrawRay(transform.position, CurPosition, Color.blue, Time.deltaTime);
            //Debug.DrawLine(cam.transform.position, cam.transform.forward, Color.blue, Time.deltaTime);

            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, CurPosition, out hit, 500f))
            {
                Debug.DrawLine(cam.transform.position, hit.point, Color.cyan, Time.deltaTime);

            }

            //GetComponent<Rigidbody>().AddForce(cam.transform.forward * 100);

            yield return new WaitForFixedUpdate();
        }
        //松开鼠标

        StopMoving();

    }

    void StartMoving()
    {
        moving = true;

        gameObject.layer = LayerMask.NameToLayer("Default");

        rb.isKinematic = false;

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        foreach (Transform child in transform)
        {
            if (child.CompareTag("Node"))
            {
                foreach (Transform grandchild in child.transform)
                {
                    if (grandchild.CompareTag("WeldPoint"))
                    {
                        //Debug.Log("qwe");

                        grandchild.GetComponent<WeldPoint>().SetMoving(true);

                    }
                }

            }
        }

    }

    public void StopMoving()
    {
        moving = false;

        rb.isKinematic = true;
        gameObject.layer = LayerMask.NameToLayer("Item");

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        foreach (Transform child in transform)
        {
            if (child.CompareTag("WeldPoint"))

                child.GetComponent<WeldPoint>().SetMoving(false);
        }
    }



}
