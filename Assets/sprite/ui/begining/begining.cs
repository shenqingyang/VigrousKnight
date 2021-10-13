using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class begining : MonoBehaviour
{
    public GameObject gate;
    public static bool start;
    private void Start()
    {
        gate.SetActive(false);

    }
    private void FixedUpdate()
    {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    // Start is called before the first frame update
    public void StartGame()
    {
        gate.SetActive(true);
        gameObject.SetActive(false);
    }
    

        }
