using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Text text;
    public static int health;
    public static int max=5;
    private Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        health = max;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (float)health / (float)max;
        text.text = health.ToString() + "/" + max.ToString();
    }
}
