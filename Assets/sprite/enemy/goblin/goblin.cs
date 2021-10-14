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

    //trigger���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health > 0)
        {

        }
    }


    //����ai
    void Ai()
    {
        distance = Vector2.Distance(transform.position, player.position);
        if (distance > 8f)
        {
            weapon.GetComponent<spear>().Remake();

            //��������ɵ������ƶ�
            transform.position = Vector2.MoveTowards(transform.position, moveDir, speed * Time.deltaTime);
            if (moveTime > 0)
            {
                if (Vector2.Distance(transform.position, moveDir) < 0.1f)//����������ɵ�λ��
                {
                    if (waitTime <= 0)//ԭ�صȴ�ʱ�����
                    {
                        //����������һ������
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
            else//��ʱ������һ��λ��
            {
                moveDir = new Vector2((transform.position.x + Random.Range(-10, 10)) * speed * Time.deltaTime, (transform.position.y + Random.Range(-10, 10)) * speed * Time.deltaTime);
                moveTime = 3;
            }
            moveTime -= Time.deltaTime;
        }
        else if (distance <= 8f )//������ƶ�
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

    //�ܶ�����
    void SwitchAnim(){
        //�ı䶯��
        if (Vector2.Distance(transform.position, moveDir) > 0.1f)
        {
            anim.SetTrigger("running");
        }

        //�ı����ﳯ��
        if (transform.position.x > moveDir.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x < moveDir.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //�ر������ж�
    void SwitchHurtAnim()
    {
        if (ishurt)//�����ж�
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

    //����λ�������˶���
    public void HurtAnim(Transform ts)
    {
        //���˺��ƶ�
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

        //�л����˶���
        anim.SetTrigger("hurt");
    }

    //�ܵ��˺���Ѫ
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

}
