using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            { 
                SceneManager.LoadScene("load");

                if (SceneManager.GetActiveScene().name == "1-1")
                {
                    SceneManager.LoadScene("complete");
                }
            }
        }
    }

}
