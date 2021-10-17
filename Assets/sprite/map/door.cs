using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public BoxCollider2D coll;
    public BoxCollider2D trigger;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("enemy") == null)
        {
            CloseWall();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OpenWall();     
        }
    }

    public void OpenWall()
    {

        coll.enabled = true;
        trigger.enabled = false;

    }

    public void CloseWall()
    {     
        coll.enabled = false;
        trigger.enabled = true;
    }
}
