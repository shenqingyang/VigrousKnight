using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heathbottle : MonoBehaviour
{
    public float distance;
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (healthBar.health+2 < PlayerControler.maxhealth)
                {
                    healthBar.health += 2;
                }
                else
                {
                    healthBar.health = PlayerControler.maxhealth;
                }
                Destroy(gameObject);
            }
        }
    }
    
}
