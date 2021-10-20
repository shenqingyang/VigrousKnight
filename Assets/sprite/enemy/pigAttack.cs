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

          //给玩家伤害
            collision.gameObject.GetComponent<PlayerControler>().TakeDamage(damage);

            //给玩家受伤动画
            collision.gameObject.GetComponent<PlayerControler>().HurtAnim(transform);

        }
    }
}
