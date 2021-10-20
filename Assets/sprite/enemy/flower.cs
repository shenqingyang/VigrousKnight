using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour
{
    public Transform muzzlepos;
    public GameObject bullet;

    public int health = 10;
    public Animator anim;
    private bool ishurt;
    private float hurtTime = 0.3f;
    public GameObject damageNumUi;
    public GameObject dieimage;
    public bool hurttofind;
    public float hurttofindtime;

    public float attactwaittime;

    public float distance_findPlayer;

    public float distance;

    public Vector2 dir;
    private float angle;
    public GameObject coin;
    public GameObject energy;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthBar.health > 0)
        {
            distance = Vector2.Distance(transform.position, PlayerControler.position);
            if (health > 0)
            {
                if (!ishurt)
                {
                    Ai();
                }
                else
                {
                    hurttofind = true;
                    SwitchHurtAnim();
                }


            }
            else
            {
                Instantiate(dieimage, transform.position, Quaternion.identity);
                for (int i = 0; i < Random.Range(2, 6); i++)
                {
                    Vector2 coinpos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
                    Instantiate(coin, coinpos, Quaternion.identity);
                }
                for (int i = 0; i < Random.Range(2, 6); i++)
                {
                    Vector2 energypos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
                    Instantiate(energy, energypos, Quaternion.identity);
                }
                dieimage.transform.localScale = transform.localScale;
                Destroy(gameObject);
            }

            if (hurttofind)
            {
                if (hurttofindtime > 0)
                {
                    if (attactwaittime <= 0)
                    {
                        Attack();

                    }
                    else
                    {
                        attactwaittime -= Time.deltaTime;
                    }

                    hurttofindtime -= Time.deltaTime;
                }
                else
                {
                    hurttofind = false;
                }
            }
        }
    }





    //敌人ai
    void Ai()
    {
        if (distance <= distance_findPlayer)//向玩家移动
        {            
                if (attactwaittime <= 0)
                {
                    Attack();
         
                }
                else
                {
                    attactwaittime -= Time.deltaTime;
                }
            }
    }


     void Attack()
    {
        dir = PlayerControler.position-muzzlepos.position;
        attactwaittime = 3;
        anim.SetTrigger("attack");
        for (int i = 0; i < 6; i++)
        {
            GameObject flower_bullect = Instantiate(bullet, muzzlepos.position, Quaternion.identity);
            flower_bullect.GetComponent<enemy_bullet>().setspeed(Quaternion.AngleAxis(angle, Vector3.forward)*dir);
            angle += 60;
        }
        angle=0;
    }


    //关闭受伤判定
    void SwitchHurtAnim()
    {
        if (ishurt)//受伤判定
        {
            if (hurtTime <= 0)
            {
                ishurt = false;
                hurtTime = 0.3f;
            }
            else
            {
                hurtTime -= Time.deltaTime;
            }
        }


    }

    //受伤位移与受伤动画
    public void HurtAnim()
    {
        ishurt = true;

        //切换受伤动画
        anim.SetTrigger("hurt");
    }

    //受到伤害减血
    public void TakeDamage(int damage)
    {
        health -= damage;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health > 0)
        {
            if (collision.gameObject.tag == "bullet")
            {
                TakeDamage(collision.gameObject.GetComponent<bulletinformation>().damage);
                HurtAnim();
                damageNum damagable = Instantiate(damageNumUi, collision.gameObject.transform.position, Quaternion.identity).GetComponent<damageNum>();
                damagable.ShowDamageNum(collision.gameObject.GetComponent<bulletinformation>().damage);
            }
            if (collision.gameObject.tag == "weapon")
            {
                TakeDamage(collision.gameObject.GetComponent<weaponinformation>().damage);
                HurtAnim();
                damageNum damagable = Instantiate(damageNumUi, collision.gameObject.transform.position, Quaternion.identity).GetComponent<damageNum>();
                damagable.ShowDamageNum(collision.gameObject.GetComponent<weaponinformation>().damage);
            }
        }
    }
}
