using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasma_bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rd;
    public float existtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (existtime > 0)
        {
            existtime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
     
    public  void setspeed(Vector2 dir)
    {
        
        rd.velocity = dir.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall" || collision.tag == "enemy")
        {
            //collision.GetComponent<enemy>().
            Destroy(gameObject);
        }
    }

}
