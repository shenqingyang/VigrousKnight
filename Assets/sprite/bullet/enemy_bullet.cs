using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rd;
    public Transform ts;
    public float existtime;
    public int damage;
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

    public void setspeed(Vector2 dir)
    {
        rd.velocity = dir.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControler>().TakeDamage(damage);
            collision.gameObject.GetComponent<PlayerControler>().HurtAnim(ts);
            Destroy(gameObject);
        }

        if (collision.tag == "wall")
        {
            Destroy(gameObject);
        }
    }

}