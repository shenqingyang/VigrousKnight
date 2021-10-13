using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speed;
    private bool ishurt;
    public Animator camAnim;
    private Renderer thisrender;
    private float shildtime=1f;
    private float hurtTime = 0.3f;
    // Start is called before the first frame update

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        thisrender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthBar.health > 0)
        {
            if (!ishurt)
            {
                Movement();
            }
            SwitchAnim();
        }
        else
        {
            anim.SetBool("die", true);
            rb.drag = 1;
            if (gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    


    //trigger检测
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collection" && Input.GetKey(KeyCode.Space))
        {
            //破环碰撞物
            Destroy(collision.gameObject);
            if (healthBar.health < 5)
            {
                healthBar.health += 1;
            }
        }

}

    //碰撞检测
    private void OnCollisionEnter2D(Collision2D collision)
    {

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

        //人物静止使增加盾牌值
        if (horizontal == 0 && vertical == 0)
        {
            AddShild();
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

    //停止移动时增加盾牌值
    void AddShild()
    {
        if (shildBar.shild < shildBar.max && healthBar.health > 0)
        {
            shildtime -= Time.deltaTime;
            if (shildtime <= 0)
            {
                shildBar.shild += 1;
                shildtime = 1.0f;
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
        camAnim.SetTrigger("shake");

        //受伤动画
        anim.SetTrigger("hurt");
    }
}
