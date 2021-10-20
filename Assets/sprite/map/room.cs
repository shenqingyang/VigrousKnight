using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class room : MonoBehaviour
{
    private int CreatEnemyTerm;
    public GameObject passageup, passagedown, passageleft, passageright;
    public bool up,down,left,right;
    public int step;
    public int passagenum;
    public BoxCollider2D trigger;
    public BoxCollider2D coll;
    public GameObject wall_floor;
    public GameObject box;
    public bool Creatbox;
    public  bool isnb;
    public bool Creatweaponbox;

    [Header("敌人")]
    public GameObject[] enemy;
    [Header("精英怪")]
    public GameObject[] enemy_nb;
    // Start is called before the first frame update
    void Start()
    {
        CreatEnemyTerm = Random.Range(2, 3);

        //关闭通道
        passagedown.SetActive(down);
        passageleft.SetActive(left);
        passageright.SetActive(right);
        passageup.SetActive(up);
        coll.enabled = false;
        wall_floor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    if(CreatEnemyTerm==0&& GameObject.FindGameObjectWithTag("enemy") == null && !Creatbox&&!Creatweaponbox)
        {
                Vector2 move = new Vector2(transform.position.x + Random.Range(-6.5f, 6.5f), transform.position.y + Random.Range(-6.5f, 6.5f));
                Instantiate(box, move, Quaternion.identity);
                Creatbox = true;

        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            wall_floor.SetActive(true);
            if (GameObject.FindGameObjectWithTag("enemy") == null&&passagenum !=1&&!Creatweaponbox)
                {
                CreateEnemy();
            }
               
        }

    }



    public void CreateEnemy()
    {
        if (CreatEnemyTerm > 0)
        {
            if (isnb)
            {
                //生成
                for (int i = 0; i < Random.Range(3, 5); i++)
                {
                    Vector2 move = new Vector2(transform.position.x + Random.Range(-6.5f, 6.5f), transform.position.y + Random.Range(-6.5f, 6.5f));
                    Instantiate(enemy_nb[Random.Range(0, enemy_nb.Length)], move, Quaternion.identity);
                }
            }
            else
            {
                for (int i = 0; i < Random.Range(3, 5); i++)
                {
                    Vector2 move = new Vector2(transform.position.x + Random.Range(-6.5f, 6.5f), transform.position.y + Random.Range(-6.5f, 6.5f));
                    Instantiate(enemy[Random.Range(0, enemy.Length)], move, Quaternion.identity);
                }

                for(int i = 0; i < Random.Range(0, 1); i++)
                {
                    Vector2 move = new Vector2(transform.position.x + Random.Range(-6.5f, 6.5f), transform.position.y + Random.Range(-6.5f, 6.5f));
                    Instantiate(enemy_nb[Random.Range(0, enemy_nb.Length)], move, Quaternion.identity);
                }
               
            }
            CreatEnemyTerm -= 1;
        }
    }

    public void UpdateRoom(float x,float y)
    {
        passagenum = 0;

        //计算步数
        step = (int)Mathf.Abs((transform.position.x -x)/ roomgenerator.x )+ (int)Mathf.Abs((transform.position.y -y)/ roomgenerator.y);

        //计算通道数
        if (up)
            passagenum++;
        if (down)
            passagenum++;
        if (left)
            passagenum++;
        if (right)
            passagenum++;


    }



}

[System.Serializable]

public  class Enemy
{

}

