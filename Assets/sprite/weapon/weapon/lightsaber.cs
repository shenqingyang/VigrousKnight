using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsaber : MonoBehaviour
{
    public float waittime;
    public Vector3 mouse;
    public Vector3 dir;
    public float time;
    public int cost;
    public float angle;
    public static bool attack;
    public GameObject saber;

    // Start is called before the first frame update
    void Start()
    {

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
            if (attack)
            {
                angle = 60;
                
            }
            else
            {
                angle = 150;
            }
            transform.Rotate(0, 0, angle);
            Attack();

        }
    }

    public void Attack()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }


        if (Input.GetButton("Fire1"))
        {
            if (time <= 0)
            {
                saber.SetActive(true);
                attack = true;
                time = waittime;
            }
        }
    }


}
