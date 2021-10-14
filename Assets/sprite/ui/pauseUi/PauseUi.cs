using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUi : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }

    public void Continue()
    {
        text.text = "";
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Home()
    {
        text.text ="";
        gameObject.SetActive(false);
        SceneManager.LoadScene("begining");
    }
    public void Setting()
    {
        text.text = "作者是懒狗，没有做这个功能";
    }
}
