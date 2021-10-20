using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxdestory : MonoBehaviour
{
    public int health;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            anim.SetTrigger("die");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health > 0)
        {
            if (collision.gameObject.tag == "bullet")
            {
                health -= collision.gameObject.GetComponent<bulletinformation>().damage;
            }
            if (collision.gameObject.tag == "enemy_bullet")
            {
                health -= collision.gameObject.GetComponent<bulletinformation>().damage;
            }
            if (collision.gameObject.tag == "weapon")
            {
                health -= collision.gameObject.GetComponent<weaponinformation>().damage;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy_weapon" )
        {
            health -= collision.gameObject.GetComponent<pigAttack>().damage;
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
