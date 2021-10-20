using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saber : MonoBehaviour
{
    public PolygonCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void open()
    {

        coll.enabled = true;
    }

    public void off()
    {
        coll.enabled = false;
    }

    public void die()
    {
        lightsaber.attack = false;
        gameObject.SetActive(false);
        Debug.Log("0");
    }
}
