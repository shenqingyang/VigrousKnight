using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    public static int health=5;
    public float speed;
    public float speedrun;
    public GameObject weapon;
    public Transform player;
    public Animator anim;
    public Rigidbody2D rb;
    private bool ishurt;
    private float hurtTime = 0.3f;
    public float attacttime;


    public Vector2 moveDir;
    public static float distance;
    public float waitTime;
    public float moveTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

            if (health > 0)
            {
                if (!ishurt)
                {
                    Ai();

                    SwitchAnim();
                }
                else
                {
                    SwitchHurtAnim();
                }
            }
            else
            {
                anim.SetTrigger("die");
                gameObject.GetComponent<Rigidbody2D>().drag = 1;
                if (gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
                {
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
    }

    //trigger检测
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health > 0)
        {

        }
    }


    //敌人ai
    void Ai()
    {
        distance = Vector2.Distance(transform.position, player.position);
        if (distance > 8f)
        {
            weapon.GetComponent<spear>().Remake();

            //向随机生成的坐标移动
            transform.position = Vector2.MoveTowards(transform.position, moveDir, speed * Time.deltaTime);
            if (moveTime > 0)
            {
                if (Vector2.Distance(transform.position, moveDir) < 0.1f)//到达随机生成的位置
                {
                    if (waitTime <= 0)//原地等待时间结束
                    {
                        //重新生成下一个坐标
                        moveDir = new Vector2((transform.position.x + Random.Range(-10, 10)), (transform.position.y + Random.Range(-10, 10)));
                        moveTime = 3;
                        waitTime = Random.Range(1, 2);
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
            else//超时生成下一个位置
            {
                moveDir = new Vector2((transform.position.x + Random.Range(-10, 10)) * speed * Time.deltaTime, (transform.position.y + Random.Range(-10, 10)) * speed * Time.deltaTime);
                moveTime = 3;
            }
            moveTime -= Time.deltaTime;
        }
        else if (distance <= 8f )//向玩家移动
        {
            if (healthBar.health > 0)
            {
                if (distance > 1.8f)
            {
                weapon.GetComponent<spear>().ToPlayer();
                moveDir = new Vector2(player.position.x, player.position.y);
                transform.position = Vector2.MoveTowards(transform.position, moveDir, speedrun * Time.deltaTime);
            }

                if (distance <= 2.5f)
                {
                    if (attacttime <= 0)
                    {
                        weapon.GetComponent<spear>().Attack();
                        attacttime = 2;
                    }
                    else
                    {
                        attacttime -= Time.deltaTime;
                    }
                }

            }
        }
    }

    //跑动动画
    void SwitchAnim(){
        //改变动画
        if (Vector2.Distance(transform.position, moveDir) > 0.1f)
        {
            anim.SetTrigger("running");
        }

        //改变人物朝向
        if (transform.position.x > moveDir.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x < moveDir.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
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
    public void HurtAnim(Transform ts)
    {
        //受伤后移动
        if (transform.position.x < ts.transform.position.x)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            ishurt = true;
        }
        if (transform.position.x > ts.transform.position.x)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            ishurt = true;
        }
        if (transform.position.y < ts.transform.position.y)
        {
            rb.velocity = new Vector2(rb.velocity.x, -5);
            ishurt = true;
        }
        if (transform.position.y > ts.transform.position.y)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
            ishurt = true;
        }

        //切换受伤动画
        anim.SetTrigger("hurt");
    }

    //受到伤害减血
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

}
