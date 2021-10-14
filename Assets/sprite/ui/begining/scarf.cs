using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scarf : MonoBehaviour
{ 
    public float color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (color <= 1)
        {
            color += Time.deltaTime;
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, color);
        }
    }
}
