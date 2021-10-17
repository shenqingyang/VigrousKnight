using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour
{
    public GameObject damageNumUi;
    public static int damage = 4;
    private Animator anim;
    private Transform ts;
    public BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ts = GetComponent<Transform>();
        coll.enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
     
    }

    //检测攻击玩家
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
                //给玩家伤害
                collision.gameObject.GetComponent<PlayerControler>().  TakeDamage(damage);

            //给玩家受伤动画
            collision.gameObject.GetComponent<PlayerControler>().HurtAnim(ts);

            //生成伤害数值UI
            damageNum damagable = Instantiate(damageNumUi, collision.gameObject.transform.position, Quaternion.identity).GetComponent<damageNum>();
                damagable.ShowDamageNum(damage);
        }

    }

    //攻击动画
    public void Attack()
    {
        anim.SetTrigger("attack");
    }

    //指向玩家
    public void ToPlayer()
    {
        Vector2 dir = PlayerControler.position - ts.position;
        transform.up = dir;
        transform.Rotate(0,0,90);
    }


    //开启碰撞器
    void OpenColl()
    {
        coll.enabled = true;
    }

    //关闭碰撞器
    void CloseColl()
    {
        coll.enabled = false;
    }

    public void Remake()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }

}
