using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!exit.open)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                exit.open = true;
                exit.active = true;
                gameObject.SetActive(false);
            }
        }
    }
}
