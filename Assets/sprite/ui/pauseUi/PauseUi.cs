using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUi : MonoBehaviour
{
    public GameObject button;
    public Text text;
    public GameObject Ui;
    public static bool end;
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Ui.SetActive(false);
            Time.timeScale = 1;

        }

        if (end)
        {
            button.SetActive(false);
            Ui.SetActive(false);
            end = false;
        }

    }

    public void Continue()
    {
        text.text = "";
        Time.timeScale = 1;
        Ui.SetActive(false);
    }

    public void Home()
    {
        text.text ="";
        Ui.SetActive(false);
        normalUi.end = true;
        normalUi.Ui2 = true;
        SceneManager.LoadScene("begining");
    }
    public void Setting()
    {
        text.text = "作者是懒狗，没有做这个功能";
    }

    public void Pause()
    {
        if (healthBar.health > 0)
        {
            Time.timeScale = 0;
            Ui.SetActive(true);
        }
    }
}
