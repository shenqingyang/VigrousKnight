using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_weapon : MonoBehaviour
{
    public Animator anim;
    public float distance;
    public GameObject[] weapon;
    public GameObject openimage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (distance <= 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int num = Random.Range(0, weapon.Length);
                Vector2 pos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
                GameObject ins = Instantiate(weapon[num], pos, Quaternion.identity);
                ins.name = ins.name.Replace("(Clone)", "");
                anim.SetTrigger("open");
                Instantiate(openimage, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}

