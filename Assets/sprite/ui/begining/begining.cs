using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class begining : MonoBehaviour
{
    public GameObject start;
    public GameObject scarf;
    public GameObject Ui1, Ui2;
    public static bool newback;
    public static bool endback;

    private void Awake()
    {
        Time.timeScale = 1;
        Ui1.SetActive(false);
        Ui2.SetActive(false);
    }
    private void Start()
    {
        if (normalUi.Ui1)
        {
            Ui1.SetActive(true);
        }
        if (normalUi.Ui2)
        {
            Ui2.SetActive(true);
        }

    }
    private void FixedUpdate()
    {
        if (newback)
        {
            start.SetActive(true);
            newback = false;
        }

        if (endback)
        {
            start.SetActive(true);
            endback = false;
        }
    }
    // Start is called before the first frame update
    public void StartG()
    {
        newButton.open = true;
        scarf.SetActive(true);
        start.SetActive(false);
    }

    public void NewGame()
    {
        normalUi.scen = 1;
        normalUi.start = true;
        SceneManager.LoadScene("load");
    }

    public void ContinueGame()
    {
        normalUi.scen -= 1;
        normalUi.iscontinue = true;
        SceneManager.LoadScene("load");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
