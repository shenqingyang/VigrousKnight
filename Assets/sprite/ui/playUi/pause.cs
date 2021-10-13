using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseUi.SetActive(true);
        }
    }
    public void PauseUi()
    {
        Time.timeScale = 0;
        pauseUi.SetActive(true);
    }
}
