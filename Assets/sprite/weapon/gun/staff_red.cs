using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staff_red : MonoBehaviour
{
    public float waittime;
    public Transform muzzlepos;
    public GameObject bullet;
    public Vector3 mouse;
    public Vector3 dir;
    public float time;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        muzzlepos = transform.Find("muzzle");
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.health > 0)
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = transform.position.z;
            transform.up = dir;
            dir = mouse - transform.position;
            transform.up = dir;
            transform.Rotate(0, 0, 90);
            fire();
        }
    }

    void fire()
    {
        if (energyBar.energy > 0)
        {


            if (time > 0)
            {
                time -= Time.deltaTime;
            }


            if (Input.GetButton("Fire1"))
            {
                if (time <= 0)
                {
                    shoot();
                    time = waittime;
                }
            }
        } 
    }

        void shoot()
        {
            energyBar.energy -= cost;
            GameObject plasma_bullect = Instantiate(bullet, muzzlepos.position, Quaternion.identity);
            plasma_bullect.GetComponent<staff_red_bullet>().setspeed(Quaternion.AngleAxis(-15, Vector3.forward) * dir);
            plasma_bullect.transform.up = dir;
            plasma_bullect.transform.Rotate(0, 0, 75);

            GameObject plasma_bullect1 = Instantiate(bullet, muzzlepos.position, Quaternion.identity);
            plasma_bullect1.GetComponent<staff_red_bullet>().setspeed(Quaternion.AngleAxis(15, Vector3.forward) * dir);
            plasma_bullect1.transform.up = dir;
            plasma_bullect1.transform.Rotate(0, 0, 105);

            GameObject plasma_bullect2 = Instantiate(bullet, muzzlepos.position, Quaternion.identity);
            plasma_bullect2.GetComponent<staff_red_bullet>().setspeed(dir);
            plasma_bullect2.transform.up = dir;
            plasma_bullect2.transform.Rotate(0, 0, 90);

            GameObject plasma_bullect3 = Instantiate(bullet, muzzlepos.position, Quaternion.identity);
            plasma_bullect3.GetComponent<staff_red_bullet>().setspeed(Quaternion.AngleAxis(-30, Vector3.forward) * dir);
            plasma_bullect3.transform.up = dir;
            plasma_bullect3.transform.Rotate(0, 0, 60);

            GameObject plasma_bullect4 = Instantiate(bullet, muzzlepos.position, Quaternion.identity);
            plasma_bullect4.GetComponent<staff_red_bullet>().setspeed(Quaternion.AngleAxis(30, Vector3.forward) * dir);
            plasma_bullect4.transform.up = dir;
            plasma_bullect4.transform.Rotate(0, 0, 120);

            GameObject plasma_bullect5 = Instantiate(bullet, muzzlepos.position, Quaternion.identity);
            plasma_bullect5.GetComponent<staff_red_bullet>().setspeed(Quaternion.AngleAxis(-45, Vector3.forward) * dir);
            plasma_bullect5.transform.up = dir;
            plasma_bullect5.transform.Rotate(0, 0, 45);

            GameObject plasma_bullect6 = Instantiate(bullet, muzzlepos.position, Quaternion.identity);
            plasma_bullect6.GetComponent<staff_red_bullet>().setspeed(Quaternion.AngleAxis(45, Vector3.forward) * dir);
            plasma_bullect6.transform.up = dir;
            plasma_bullect6.transform.Rotate(0, 0, 135);

        }

    }
