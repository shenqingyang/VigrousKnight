using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigAttack : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

          //������˺�
            collision.gameObject.GetComponent<PlayerControler>().TakeDamage(damage);

            //��������˶���
            collision.gameObject.GetComponent<PlayerControler>().HurtAnim(transform);

        }
    }
}
