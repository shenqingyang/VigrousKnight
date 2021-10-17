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
    // Start is called before the first frame update
    void Start()
    {
        muzzlepos = transform.Find("muzzle");
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = transform.position.z;
        transform.up = dir;
        transform.Rotate(0, 0, 90);
        fire();
    }

   void fire()
    {
        dir = mouse - transform.position;
        transform.up = dir;
        transform.Rotate(0, 0, 90);

        if (waittime > 0)
        {
            waittime -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }

        if (Input.GetButton("Fire1"))
        {
            if (time <= 0)
            {
                shoot();
                time = waittime;
            }
        }

        void shoot()
        {
            GameObject plasma_bullect = Instantiate(bullet, muzzlepos.position, Quaternion.identity);
            float angle = Random.Range(-5, 5);
            plasma_bullect.GetComponent<plasma_bullet>().setspeed(Quaternion.AngleAxis(angle, Vector3.forward) * dir);
        }

    }
}
