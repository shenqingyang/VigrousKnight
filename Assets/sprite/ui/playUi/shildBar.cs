using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shildBar : MonoBehaviour
{
    public Text text;
    public static int shild;
    private Image shildbar;
    public  float shildtime=1;
    public float waittime;


    // Start is called before the first frame update
    void Start()
    {
        shild = PlayerControler.maxshild;
        DontDestroyOnLoad(this);
        shildbar = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shildbar.fillAmount = (float)shild / (float)PlayerControler.maxshild;
        text.text = shild.ToString() + "/" + PlayerControler.maxshild.ToString();
        if (healthBar.health > 0)
        {
            AddShild();
        }

            }

    //∂‹≈∆÷µ
    void AddShild()
    {

        if (PlayerControler.ishurt)
        {
            waittime = 3;
        }
        if (waittime <= 0)
        {

            if (shild < PlayerControler.maxshild)
            {
                if (shildtime <= 0)
                {
                    shild += 1;
                    shildtime = 1.0f;
                }
                else
                {
                    shildtime -= Time.deltaTime;
                }
            }
        }
        else
        {
            waittime -= Time.deltaTime;
        }


    }
}
