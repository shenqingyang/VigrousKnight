using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScen : MonoBehaviour
{
    public float waittime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (waittime <= 0)
            {
            waittime = 1;
            normalUi.Ui.SetActive(true);
            SceneManager.LoadScene(normalUi.scen+1);

            }
            else
            {
                waittime -= Time.deltaTime;
            }

    }
}
