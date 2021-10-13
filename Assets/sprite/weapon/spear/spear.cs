using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour
{
    public GameObject damageNumUi;
    public static int damage = 4;
    private Animator anim;
    private Transform ts;
    public Transform player;
    public float attackTime;
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
        if (healthBar.health > 0)
        {
            if (goblin.health > 0)
            {
                if (goblin.distance >= 6f)
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    ToPlayer();
                    if (goblin.distance <= 2f)
                    {
                        if (attackTime <= 0)
                        {
                            Attack();
                            attackTime = 2;
                        }
                        else
                        {
                            attackTime -= Time.deltaTime;
                        }
                    }
                }
            }
        }
    }

    //��⹥�����
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (healthBar.health > 0)
            {
                //������˺�
                collision.gameObject.GetComponent<PlayerControler>().TakeDamage(damage);

                //��������˶���
                collision.gameObject.GetComponent<PlayerControler>().HurtAnim(ts);

                //�����˺���ֵUI
                damageNum damagable = Instantiate(damageNumUi, collision.gameObject.transform.position, Quaternion.identity).GetComponent<damageNum>();
                damagable.ShowDamageNum(damage);
            }
        }

    }

    //��������
    public void Attack()
    {
        anim.SetTrigger("attack");

    }

    //ָ�����
    public void ToPlayer()
    {
        Vector2 dir = player.position - ts.position;
        transform.up = dir;
        transform.Rotate(0,0,90);
    }


    //������ײ��
    void OpenColl()
    {
        coll.enabled = true;
    }

    //�ر���ײ��
    void CloseColl()
    {
        coll.enabled = false;
    }
}