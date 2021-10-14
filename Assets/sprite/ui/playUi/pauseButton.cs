using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour
{
    public GameObject pauseUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.health > 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                pauseUi.SetActive(true);
            }
        }
    }
    public void PauseUi()
    {
        Time.timeScale = 0;
        pauseUi.SetActive(true);
    }
}
