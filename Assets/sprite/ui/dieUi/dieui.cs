using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dieui : MonoBehaviour
{
    public Text text;
    public GameObject endgame;
    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RemakeButton()
    {
        text.text = "œÎ∆®≥‘";
    }

    public void BackButton()
    {
        endgame.SetActive(true);
        text.text = "∏¥ªÓ";
        gameObject.SetActive(false);
    }
}
