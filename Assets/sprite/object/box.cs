using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public Animator anim;
    public float distance;
    public GameObject[] item;
    public GameObject openimage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, PlayerControler.position);
        if (distance <= 4)
        {
            anim.SetTrigger("open");
            for(int i = 0; i < Random.Range(8, 15); i++)
            {
                int num = Random.Range(0, item.Length);
                Vector2 pos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
                Instantiate(item[num], pos, Quaternion.identity);
                if (num == 2 )
                {
                    item[2] = item[0];
                }
                if (num == 3)
                {
                    item[3] = item[1];
                }
                Instantiate(openimage, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    

}
