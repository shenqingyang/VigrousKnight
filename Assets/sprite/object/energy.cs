using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
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
            transform.position = Vector2.MoveTowards(transform.position, PlayerControler.position, 10 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (energyBar.energy + 5 < PlayerControler.maxenergy)
            {
                energyBar.energy += 5;
            }
            else
            {
                energyBar.energy = PlayerControler.maxenergy;
            }
            Destroy(gameObject);
        }
    }

}
