using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillUI : MonoBehaviour
{
    public Image skillBar;
    public static float skilltime=3;
    public static float waittime;
    // Start is called before the first frame update
    void Start()
    {
        waittime = 5;
        skillBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControler.weaponcopy_on)
        {
            skillBar.color = new Color(255, 255, 255, 255);
            if (skilltime < 3 && skilltime >= 0)
            {
                skillBar.fillAmount = skilltime / 3f;
            }
        }
        else
        {
            skillBar.fillAmount = waittime / 5f;
        }
        if (waittime == 5&&!PlayerControler.weaponcopy_on)
        {
            skillBar.color = new Color(0, 255, 255, 255);
        }
    }
}
