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

    [Header("敌人")]
    public GameObject[] enemy;
    // Start is called before the first frame update
    void Start()
    {
        CreatEnemyTerm = Random.Range(2, 3);

        //关闭通道
        passagedown.SetActive(down);
        passageleft.SetActive(left);
        passageright.SetActive(right);
        passageup.SetActive(up);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
                if (GameObject.FindGameObjectWithTag("enemy") == null&&passagenum !=1)
                {
                CreateEnemy();
            }
        }

    }



    public void CreateEnemy()
    {
        if (CreatEnemyTerm > 0)
        {
            //生成近战哥布林
            for (int i = 0; i < Random.Range(4, 6); i++)
            {
                Vector2 move = new Vector2(transform.position.x + Random.Range(-7, 7), transform.position.y + Random.Range(-7, 7));
                Instantiate(enemy[Random.Range(0,enemy.Length)], move, Quaternion.identity);
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

