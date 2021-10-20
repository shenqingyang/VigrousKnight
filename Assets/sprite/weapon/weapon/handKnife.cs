using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handKnife : MonoBehaviour
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

    public void  close()
    {
        coll.enabled = false;
    }

    public void  end()
    {
        this.gameObject.SetActive(false);
    }

    public void open()
    {
        coll.enabled = true;
    }
}
