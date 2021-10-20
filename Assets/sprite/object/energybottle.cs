using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energybottle : MonoBehaviour
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
                if (energyBar.energy+50 < PlayerControler.maxenergy)
                {
                    energyBar.energy += 50;
                }
                else
                {
                    energyBar.energy = PlayerControler.maxenergy;
                }
                Destroy(gameObject);
            }
        }
    }
}
