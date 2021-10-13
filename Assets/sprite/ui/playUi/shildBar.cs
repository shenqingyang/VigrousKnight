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
    }
}
