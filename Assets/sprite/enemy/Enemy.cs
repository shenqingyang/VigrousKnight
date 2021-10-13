using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //×Ô¶¯Ñ²Âßai
    public void WalkAi(Vector2 moveDir, Rigidbody2D rb, float speed, float waitTime = 1, float moveTime = 3)
    {
        transform.position = Vector2.MoveTowards(transform.position, moveDir, speed * Time.deltaTime);
        if (moveTime <= 0)
        {
            if (waitTime <= 0)
            {
                moveDir = new Vector2(Random.Range(-6, 6) * speed * Time.deltaTime, Random.Range(-6, 6) * speed * Time.deltaTime);
                moveTime = Random.Range(1, 5);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            moveTime -= Time.deltaTime;
        }
    }
}


