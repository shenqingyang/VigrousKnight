using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speed;
    public static bool ishurt;
    public Animator camAnim;
    private Renderer thisrender;
    private float hurtTime = 0.3f;
    public GameObject dieUi;
    public GameObject normalUi;
    private float dietime=2;
        // Start is called before the first frame update


    private void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
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
            if (dietime<=0)
            {
                dieUi.SetActive(true);
                normalUi.SetActive(false);
                gameObject.SetActive(false);
            }
            else
            {
                dietime -= Time.deltaTime;
            }
        }
    }

    


    //trigger���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collection" && Input.GetKey(KeyCode.Space))
        {
            //�ƻ���ײ��
            Destroy(collision.gameObject);
            if (healthBar.health < 5)
            {
                healthBar.health += 1;
            }
        }

}

    //��ײ���
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    //�����˶�
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal"); //A D ����
        float vertical = Input.GetAxis("Vertical"); //W S �� ��
        float move = Mathf.Abs(vertical) >= Mathf.Abs(horizontal) ? Mathf.Abs(vertical) : Mathf.Abs(horizontal);
        Vector3 mouse = Input.mousePosition;
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mouse - obj;
        //�˶�
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
        //�л�����run
        anim.SetFloat("running", Mathf.Abs(move));
        //�ı����ﳯ��
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    //�л�����
    void SwitchAnim()
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


    //player�ܵ��˺�
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

    //�������˺��ƶ������˶����뾵ͷ�ζ�
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

        //��ͷ�ζ�
        camAnim.SetTrigger("shake");

        //���˶���
        anim.SetTrigger("hurt");
    }
}
