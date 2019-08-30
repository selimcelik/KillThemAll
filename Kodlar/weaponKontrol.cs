using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class weaponKontrol : MonoBehaviour
{
    public float offset;
    public GameObject kursun;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float cooldownTime = 2f;
    private float nextFireTime = 0;
    Touch touch;
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (Time.time > nextFireTime)
        {
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(kursun, shotPoint.position, transform.rotation);
                    nextFireTime = Time.time + cooldownTime;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }

        }
    }
}
