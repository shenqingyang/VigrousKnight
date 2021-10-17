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
        if (newButton.startup)
        {
            if (color <= 1)
            {
                color += Time.deltaTime*3f;
                gameObject.GetComponent<Image>().color = new Color(255, 255, 255, color);
            }
        }

        if (newButton.startdown)
        {
            if (color >= 0)
            {
                color -= Time.deltaTime*3f;
                gameObject.GetComponent<Image>().color = new Color(255, 255, 255, color);
            }
        }

    }
}
