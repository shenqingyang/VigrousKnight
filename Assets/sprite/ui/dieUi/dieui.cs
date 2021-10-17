using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dieui : MonoBehaviour
{
    public Text text;
    public GameObject endgame;
    public GameObject Ui;
    private float dietime = 2;
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.health <= 0)
        {
            if (dietime <= 0)
            {
                Ui.SetActive(true);
                normalUi.Ui1 = true;
                normalUi.end = true;
                PauseUi.end = true;
            }
            else
            {
                dietime -= Time.deltaTime;
            }

        }
    }

    public void RemakeButton()
    {
        text.text = "ÏëÆ¨³Ô";
    }

    public void BackButton()
    {
        endgame.SetActive(true);
        text.text = "¸´»î";
        gameObject.SetActive(false);
    }
}
