using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public static bool open;
    public static bool close;
    public float up;
    public float speed;
    private Vector2 move;
    private Vector2 down;
    public static bool startdown;
    public static bool startup;
    public static bool active;

    public bool esc;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        esc = Input.GetKeyDown(KeyCode.Escape);
        if (open)
        {
            move = new Vector2(transform.position.x, transform.position.y + up);
            down = transform.position;
            startup = true;
            open = false;
        }

        if (startup)
        {
            transform.position = Vector2.MoveTowards(transform.position, move, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, move) < 0.1)
            {
                startup = false;

            }
        }

        if (!startup && active)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                startdown = true;
            }

            if (startdown)
            {
                transform.position = Vector2.MoveTowards(transform.position, down, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, down) < 0.1)
                {
                    startdown = false;
                    begining.endback = true;
                    active = false;
                }
            }
        }
    }

}
