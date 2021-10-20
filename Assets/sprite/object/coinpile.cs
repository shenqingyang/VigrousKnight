using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinpile : MonoBehaviour
{
    public int health;
    public Animator anim;
    public GameObject coin;
    public bool die;
    public BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !die)
        {
                for (int i = 0; i < Random.Range(10, 20); i++)
                {
                    Vector2 pos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
                    Instantiate(coin, pos, Quaternion.identity);
                }
            die = true;
            coll.enabled = false;
            anim.SetTrigger("die");
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health > 0)
        {
            if (collision.gameObject.tag == "bullet")
            {
                anim.SetTrigger("hurt");
                health -= collision.gameObject.GetComponent<bulletinformation>().damage;
            }
        }
    }
}
