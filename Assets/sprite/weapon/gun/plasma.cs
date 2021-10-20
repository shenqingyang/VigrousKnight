using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasma : MonoBehaviour
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
            GameObject plasma_bullect2 = Instantiate(bullet, new Vector2(muzzlepos.position.x+0.3f,muzzlepos.position.y), Quaternion.identity);
            float angle = Random.Range(-5, 5);
            plasma_bullect.GetComponent<plasma_bullet>().setspeed(Quaternion.AngleAxis(angle, Vector3.forward) * dir);
            float angle2 = Random.Range(-5, 5);
            plasma_bullect2.GetComponent<plasma_bullet>().setspeed(Quaternion.AngleAxis(angle2, Vector3.forward) * dir);
        }

    }
