using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBar : MonoBehaviour
{
    public Text text;
    public static int energy;
    public static int max=200;
    private Image energybar;
    // Start is called before the first frame update
    void Start()
    {
        energybar = GetComponent<Image>();
        energy = max;
    }

    // Update is called once per frame
    void Update()
    {
        energybar.fillAmount = (float)energy / (float)max;
        text.text = energy.ToString() + "/" + max.ToString();
    }
}
