using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class begining : MonoBehaviour
{
    public GameObject gate;
    public GameObject newgame;
    public GameObject start;
    public GameObject scarf;

    private void Awake()
    {
        Time.timeScale = 1;
        newgame.SetActive(false);
    }
    private void Start()
    {
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    // Start is called before the first frame update
    public void StartG()
    {
        newgame.SetActive(true);
        scarf.SetActive(true);
        start.SetActive(false);
    }
    
    public void NewGame()
    {
        gate.SetActive(true);
        transform.gameObject.SetActive(false);
    }

        }
