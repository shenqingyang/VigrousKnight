using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newButton : MonoBehaviour
{
    public float up;
    public float speed;
    private Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        move = new Vector2(transform.position.x, transform.position.y + up);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            transform.position = Vector2.MoveTowards(transform.position, move, speed * Time.deltaTime);
    }
}
