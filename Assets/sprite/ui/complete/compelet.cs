using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class compelet : MonoBehaviour
{
    private float time=2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            normalUi.Ui1 = true;
            SceneManager.LoadScene("begining");
        }
    }
}
