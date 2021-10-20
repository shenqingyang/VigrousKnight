using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallControl : MonoBehaviour
{
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        wall.GetComponent<BoxCollider2D>().enabled = false;
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            wall.SetActive(true);
        }
    }
}
