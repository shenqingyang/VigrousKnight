using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    public  Vector2 roomposition;
    public int health=5;
    public float speed;
    public float speedrun;
    public GameObject weapon;
    public Animator anim;
    public Rigidbody2D rb;
    private bool ishurt;
    private float hurtTime=0.3f;
    public GameObject damageNumUi;
    public GameObject dieimage;
    public float dietime;
    public bool hurttofind;
    public float hurttofindtime;
 


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
    public GameObject coin;
    public GameObject energy;


    // Start is called before the first frame update
    void Start()
    {
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
                    hurttofind = true;
                    SwitchHurtAnim();
                }

              
            }
            else
            {
                anim.SetTrigger("die");
                gameObject.GetComponent<Rigidbody2D>().drag = 1;
                if (dietime <= 0) { 
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
                else
                {
                    dietime -= Time.deltaTime;
                }
             
            }
            if (hurttofind)
            {
                if (hurttofindtime > 0)
                {
                    FindPlayer();
                    SwitchAnim();
                    if (distance <= distance_findPlayer)
                    {
                        hurttofind = false; 
                    }
                    hurttofindtime -= Time.deltaTime;
                }
                else
                {
                    hurttofind = false;
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



        //????????????????????
       
        transform.position = Vector2.MoveTowards(transform.position, moveDir, speed * Time.deltaTime);
        if (moveTime > 0)
        {
            if (Vector2.Distance(transform.position, moveDir) < 0.1f)//??????????????????
            {
                if (waitTime <= 0)//????????????????
                {
                    //            //??????????????????
                    moveDir = new Vector2(roomposition.x + Random.Range(-7, 7), roomposition.y + Random.Range(-7, 7));
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
        else//??????????????????
        {
            moveDir = new Vector2(roomposition.x + Random.Range(-7, 7), roomposition.y + Random.Range(-7, 7));
            moveTime = 3;
        } 

    }


    void FindPlayer()
    {
        weapon.GetComponent<spear>().ToPlayer();
        moveDir = new Vector2(PlayerControler.position.x, PlayerControler.position.y);
        transform.position = Vector2.MoveTowards(transform.position, moveDir, speedrun * Time.deltaTime);
    }

    //????ai
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

        if (distance <= distance_findPlayer)//??????????
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
                        transform.localScale = new Vector3(-1, 1, 1);
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

    //????????
    void SwitchAnim(){
        //????????
        if (Vector2.Distance(transform.position, moveDir) > 0.1f)
        {
            anim.SetFloat("running", Mathf.Abs(Vector2.Distance(moveDir,transform.position)));
        }

        //????????????
            if (transform.position.x > moveDir.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
        }
            else if (transform.position.x < moveDir.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
        }
    }


    //????????????
    void SwitchHurtAnim()
    {
        if (ishurt)//????????
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

    //??????????????????
    public void HurtAnim(Transform ts)
    {
        //??????????
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

        //????????????
        anim.SetTrigger("hurt");
    }

    //????????????
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health > 0)
        {
            if (collision.gameObject.tag == "bullet")
            {
                TakeDamage(collision.gameObject.GetComponent<bulletinformation>().damage);
                HurtAnim(collision.gameObject.transform);
                damageNum damagable = Instantiate(damageNumUi, collision.gameObject.transform.position, Quaternion.identity).GetComponent<damageNum>();
                damagable.ShowDamageNum(collision.gameObject.GetComponent<bulletinformation>().damage);
            }

            if (collision.gameObject.tag == "weapon")
            {
                TakeDamage(collision.gameObject.GetComponent<weaponinformation>().damage);
                HurtAnim(collision.gameObject.transform);
                damageNum damagable = Instantiate(damageNumUi, collision.gameObject.transform.position, Quaternion.identity).GetComponent<damageNum>();
                damagable.ShowDamageNum(collision.gameObject.GetComponent<weaponinformation>().damage);
            }
        }
    }

}
