using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public GameObject damageNumUi;
    public static bool tostartroom;
    public static int maxhealth=6;
    public static int maxenergy=180;
    public static int maxshild=5;
    public int weaponnum;
    public Rigidbody2D rb;
    public Animator anim;
    public float speed;
    public static bool ishurt;
    private float hurtTime = 0.3f;
    public static Vector3 position;
    public GameObject[] weapon;
    public bool skill;
    public GameObject weaponcopy;
    public static bool weaponcopy_on;
    public GameObject fire;
    public bool handknife;
    public float waittime;
    public GameObject Handknife;
    public string na;
    public GameObject[] pickweapon;
    public bool isget;
        // Start is called before the first frame update


    private void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tostartroom)
        {
            transform.position = roomgenerator.startposition;
            tostartroom = false;
        }

        position = transform.position;
        if (healthBar.health > 0)
        {
            if (!ishurt)
            {
                Movement();
                SwitchWeapon();
                if (handknife)
                {
                    HandKnife();
                }
                else
                {
                    Skill();
                }
                
            }
            SwitchAnim();
        }
        else
        {
            anim.SetBool("die", true);
            rb.drag = 1;
        }
    }


    //人物运动
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        float vertical = Input.GetAxis("Vertical"); //W S 上 下
        float move = Mathf.Abs(vertical) >= Mathf.Abs(horizontal) ? Mathf.Abs(vertical) : Mathf.Abs(horizontal);
        Vector3 mouse = Input.mousePosition;
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mouse - obj;
        //运动
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
        //切换动画run
        anim.SetFloat("running", Mathf.Abs(move));
        //改变人物朝向
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    //切换动画
    void SwitchAnim()
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




    //player受到伤害
    public void TakeDamage(int damage)
    {
        if (damage > shildBar.shild)
        {
            int cut = damage - shildBar.shild;
            shildBar.shild = 0;
            if (cut > healthBar.health)
            {
                healthBar.health = 0;
            }
            else
            {
                healthBar.health -= cut;
            }
        }
        else
        {
            shildBar.shild -= damage;
        }
        damageNum damagable = Instantiate(damageNumUi, position, Quaternion.identity).GetComponent<damageNum>();
        damagable.ShowDamageNum(damage);
    }

    //人物受伤后移动与受伤动画与镜头晃动
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

        //镜头晃动
        cameraControl.hurt = true;

        //受伤动画
        anim.SetTrigger("hurt");
    }

    public GameObject FindWeapon(GameObject parent, string name)
    {
        GameObject weapon = null;
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).gameObject.name == name)
            {
                weapon = parent.transform.GetChild(i).gameObject;
                break;
            }
        }
        return weapon;
    }

    void SwitchWeapon() {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weapon[weaponnum].SetActive(false);
            if (weaponnum == 0)
            {
                weaponnum = 1;
            }else if(weaponnum == 1)
            {
                weaponnum = 0;
            }
            weapon[weaponnum].SetActive(true);
        }
    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "pickweapon"&&!isget)
        {
            na = collision.name.Replace("(Clone)", "");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject change = FindWeapon(this.gameObject,na);
                if (weapon[1] == null)
                {
                    weapon[0].SetActive(false);
                    weapon[1] = change;
                    weapon[1].SetActive(true);
                    weaponnum = 1;
                }
                else
                {
                    int i = 0;
                    na = weapon[weaponnum].name;
                    for (; i < this.gameObject.transform.childCount; i++)
                    {
                        if (this.gameObject.transform.GetChild(i).gameObject.name == na)
                        {
                            break;
                        }
                    }
                    GameObject weapon_recent = Instantiate(pickweapon[i], collision.transform.position, Quaternion.identity);
                    weapon[weaponnum].SetActive(false);
                    weapon[weaponnum] = change;
                    weapon[weaponnum].SetActive(true);
                    weapon_recent.SetActive(true);
                }
                isget = true;
                Destroy(collision.gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isget = false;
        if (collision.tag == "enemy"&&weapon[0].tag=="gun")
        {
            handknife = true;
            weapon[weaponnum].SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "enemy"&&weapon[0].tag=="gun")
        {
            handknife = false;
            weapon[weaponnum].SetActive(true);
        }
    }

    public void Skill()
    {
        if (skillUI.waittime == 5) {
            if (Input.GetButton("Fire2"))
            {
                skill = true;
            }

            if (skill)
            {
                if (weapon[weaponnum].tag == "gun")
                {
                    if (!weaponcopy_on)
                    {
                        weaponcopy = GameObject.Instantiate(weapon[weaponnum], position, Quaternion.identity);
                        weaponcopy.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                        weaponcopy.transform.localScale = transform.localScale;
                        weaponcopy.transform.SetParent(transform);
                        weaponcopy.transform.position = new Vector3(weaponcopy.transform.position.x + 0.5f, weaponcopy.transform.position.y - 0.45f, weaponcopy.transform.position.z);
                        weaponcopy_on = true;
                    }
                    fire.SetActive(true);
                    if (skillUI.skilltime > 0)
                    {
                        skillUI.skilltime -= Time.deltaTime;
                    }
                    else
                    {
                        Destroy(weaponcopy);
                        fire.SetActive(false);
                        skill = false;
                        weaponcopy_on = false;
                        skillUI.skilltime = 3;
                        skillUI.waittime = 0;
                    }
                }
            }
        }
        else
        {
            skillUI.waittime += Time.deltaTime;
            if (skillUI.waittime >= 5)
            {
                skillUI.waittime = 5;
            }
        }

    }

    public void HandKnife()
    {
       if (waittime > 0)
        {
            waittime -= Time.deltaTime;
        }


        if (Input.GetButton("Fire1"))
        {
            if (waittime <= 0)
            {
                Handknife.SetActive(true);
                waittime = 0.2f;
            }
        }
    }

}
