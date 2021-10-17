using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBar : MonoBehaviour
{
    public Text text;
    public static int energy;
    private Image energybar;
    // Start is called before the first frame update
    void Start()
    {
        energy = PlayerControler.maxenergy;
        DontDestroyOnLoad(this);
        energybar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        energybar.fillAmount = (float)energy / (float)PlayerControler.maxenergy;
        text.text = energy.ToString() + "/" +PlayerControler.maxenergy.ToString();
    }

}
