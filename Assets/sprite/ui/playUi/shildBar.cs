using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shildBar : MonoBehaviour
{
    public Text text;
    public static int shild;
    public static int max = 5;
    private Image shildbar;
    private float shildtime=1;
    public float waittime;


    // Start is called before the first frame update
    void Start()
    {
        shildbar = GetComponent<Image>();
        shild = max;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shildbar.fillAmount = (float)shild / (float)max;
        text.text = shild.ToString() + "/" + max.ToString();
        if (PlayerControler.ishurt)
        {
            waittime = 3;
        }
        if (waittime <= 0)
        {
            AddShild();
        }
        else
        {
            waittime -= Time.deltaTime;
        }

            }

    //¶ÜÅÆÖµ
    void AddShild()
    {
        if (shild < max && healthBar.health > 0)
        {
            shildtime -= Time.deltaTime;
            if (shildtime <= 0)
            {
                shild += 1;
                shildtime = 1.0f;
            }
        }
    }
}
