using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    public  Vector2 roomposition;
    public static int health=5;
    public float speed;
    public float speedrun;
    public GameObject weapon;
    public Animator anim;
    public Rigidbody2D rb;
    private bool ishurt;
    private float hurtTime=0.3f;
 


    public Vector2 moveDir;

    public float waitTime;
    public float moveTime;
    public float attactwaittime;
    public float attacktime;
    public float attackendtime;

    public float distance_findPlayer;

    public float distance_back,distance_attack;
    public float distance; 


    public bool startattack,endattack,finishattack,completeattact;


    // Start is called before the first frame update
    void Start()
    {
        //moveDir = transform.position;
        roomposition = transform.position;
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
        else
        {
            Walk();
            
            SwitchAnim();
        }

    }


void Walk()
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
                    //            //����������һ������
                    moveDir = new Vector2(roomposition.x + Random.Range(-7.5f, 7.5f), roomposition.y + Random.Range(-7.5f, 7.5f));
                    moveTime = Random.Range(4,7);
                    waitTime = Random.Range(2, 3);
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
            else
            {
                moveTime -= Time.deltaTime;
            }
        }
        else//��ʱ������һ��λ��
        {
            moveDir = new Vector2(roomposition.x + Random.Range(-8, 8), roomposition.y + Random.Range(-8, 8));
            moveTime = 3;
        } 

    }


    void FindPlayer()
    {
        weapon.GetComponent<spear>().ToPlayer();
        moveDir = new Vector2(PlayerControler.position.x, PlayerControler.position.y);
        transform.position = Vector2.MoveTowards(transform.position, moveDir, speedrun * Time.deltaTime);
    }

    //����ai
    void Ai()
    {
        if (finishattack)
        {

            if (distance > distance_findPlayer)
            {
                Walk();

                SwitchAnim();
            }
        }

        if (distance <= distance_findPlayer)//������ƶ�
        {

            if (finishattack)
            {
                if (distance >= distance_back)
                {

                    FindPlayer();
                    SwitchAnim();
                }

                if (distance <= distance_attack)
                {
                    moveDir = new Vector2(-PlayerControler.position.x - distance_back, -PlayerControler.position.y - distance_back);
                    transform.position = Vector2.MoveTowards(transform.position, moveDir, speed * 2 * Time.deltaTime);


                    if (PlayerControler.position.x < transform.position.x)
                        transform.localScale = new Vector3(-1, 1, 1);
                    if (PlayerControler.position.x < transform.position.x)
                        transform.localScale = new Vector3(1, 1, 1);
                }


                    if (attactwaittime <= 0)
                    {
                        moveDir = PlayerControler.position;
                        startattack = true;
                        finishattack = false;
                    }
                    else
                    {
                        attactwaittime -= Time.deltaTime;
                    }
                }

        }


        Attack();   
    }


    public void Attack()
    {
        if (startattack) {
            transform.position = Vector2.MoveTowards(transform.position, moveDir, speedrun * Time.deltaTime);
            SwitchAnim();
            if (attackendtime > 0)
            {
                if (Vector2.Distance(transform.position, moveDir) < 0.1f || distance <= distance_attack)
                {
                    completeattact = true;
                }

                if (completeattact) {
                    Debug.Log("sb");

                    weapon.GetComponent<Animator>().SetFloat("attack",attacktime);


                    if (attacktime <= 0)
                    {
                        startattack = false;
                        endattack = true;
                        attacktime = 0.5f;
                        attackendtime = 2;
                        completeattact = false;
                    }
                    attacktime -= Time.deltaTime;
                }
                
                attackendtime -= Time.deltaTime;

            }
            else
            {
                startattack = false;
                endattack = true;
                attacktime = 0.1f;
                attackendtime = 2;
            }
           
        }

        if (endattack) { 
        moveDir = new Vector2(-PlayerControler.position.x- distance_back, -PlayerControler.position.y - distance_back);
        transform.position = Vector2.MoveTowards(transform.position, moveDir, speedrun  * Time.deltaTime);
            
            if(PlayerControler.position.x<transform.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            if (PlayerControler.position.x < transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);

            if (distance >= distance_back)
            {
                attactwaittime = 2;
                endattack = false;
                finishattack = true;
            }
        }

    }

    //�ܶ�����
    void SwitchAnim(){
        //�ı䶯��
        if (Vector2.Distance(transform.position, moveDir) > 0.1f)
        {
            anim.SetFloat("running", Mathf.Abs(Vector2.Distance(moveDir,transform.position)));
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


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "map")
        {
            roomposition = collision.transform.position;
        }
    }

}
