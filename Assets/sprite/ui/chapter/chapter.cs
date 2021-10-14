using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter : MonoBehaviour
{
    public float waittime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waittime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
