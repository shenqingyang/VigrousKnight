using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    public float waittime;
    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (waittime > 0)
        {
            waittime -= Time.deltaTime;
        }
        else
        {
            transform.gameObject.SetActive(false);
            SceneManager.LoadScene("begining");
        }
    }
}
