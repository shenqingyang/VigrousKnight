using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_senser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "enemy" || collision.tag == "pile")
        {
            cannon_bullet.direction = collision.transform.position;
            cannon_bullet.track = true;
        }
    }
}
