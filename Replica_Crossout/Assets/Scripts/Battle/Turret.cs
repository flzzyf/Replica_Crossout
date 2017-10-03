using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float rotateSpeed = 3;

    public float fireRate = 5;
    float fireCountDown = 0;

    public float limitAngleH = 60;
    public Vector2 limitAngleV = new Vector2(0, 30);

    float initAngleH;
    float initAngleV;


    public Transform partToRotate;
    public Transform firePoint;

    public GameObject muzzleFlash;
    public GameObject impactEffect;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        //获取默认朝向，水平y和竖直x
        initAngleH = Util.EulerAngleNegativeFix(partToRotate.rotation.eulerAngles.y);

        initAngleV = Util.EulerAngleNegativeFix(partToRotate.rotation.eulerAngles.x);

    }

    void Update()
    {
        if(fireCountDown > 0)
            fireCountDown -= Time.deltaTime;
      
    }
    //瞄准目标点
    public void Aim(Vector3 _target)
    {
        Vector3 direction = _target - partToRotate.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        Vector3 rotation = lookRotation.eulerAngles;

        //y为水平，x为竖直
        //调整水平y朝向
        float fixedRotationY = Util.EulerAngleNegativeFix(rotation.y);

        fixedRotationY = Mathf.Clamp(fixedRotationY, initAngleH - limitAngleH, initAngleH + limitAngleH);
        //调整竖直x朝向
        //Debug.Log(rotation.x);

        float fixedRotationX = Util.EulerAngleNegativeFix(rotation.x);
        fixedRotationX *= -1;
        //Debug.Log(fixedRotationX);

        fixedRotationX = Mathf.Clamp(fixedRotationX, initAngleV + limitAngleV.x, initAngleV + limitAngleV.y);

        //旋转
        Quaternion finalRotation = Quaternion.Euler(new Vector3(-fixedRotationX, fixedRotationY, 0));

        partToRotate.rotation = Quaternion.Lerp(partToRotate.rotation, finalRotation, rotateSpeed * Time.deltaTime);
    }

    //开火
    public void Fire()
    {
        if (fireCountDown > 0)
            return;

        fireCountDown = 1 / fireRate;

        GameObject particle = Instantiate(muzzleFlash, firePoint.position, Quaternion.identity);
        Destroy(particle, 2f);

        audio.Play();

        RaycastHit hit;
        if(Physics.Raycast(firePoint.position, firePoint.forward, out hit, 500))
        {
            particle = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(particle, 2f);

            Debug.DrawLine(firePoint.position, hit.point, Color.blue, 1f);

        }


    }

}
