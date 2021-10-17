using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Text text;
    public static int health;
    private Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        health =PlayerControler.maxhealth;
        DontDestroyOnLoad(this);
        healthbar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (float)health / (float)PlayerControler.maxhealth;
        text.text = health.ToString() + "/" + PlayerControler.maxhealth.ToString();
    }
}
