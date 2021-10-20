using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class normalUi : MonoBehaviour
{
    public static bool start;
    public static int scen;
    public static bool end;
    public  static GameObject Ui;
    public GameObject UI1;
    public GameObject player;
    public static bool iscontinue;
    public static bool Ui1, Ui2;
    public static string scenname;

    // Start is called before the first frame update
    void Awake()
    {
        Ui = UI1;
        coinUi.coinnum = 0;
        healthBar.health = PlayerControler.maxhealth;
        energyBar.energy = PlayerControler.maxenergy;
        shildBar.shild = PlayerControler.maxshild;
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("begining");
        Ui1 = true;
    }

void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (end) {
            Ui.SetActive(false);
            end = false;
        }

        if (start) {
            coinUi.coinnum = 0;
            healthBar.health = PlayerControler.maxhealth;
            energyBar.energy = PlayerControler.maxenergy;
            shildBar.shild = PlayerControler.maxshild;
            Ui1 = false;
            Ui2 = false;
            player.SetActive(false);

            if (SceneManager.GetActiveScene().name == "1-1")
            {
                player.SetActive(true);
                start = false;
            }
        } 


        if (SceneManager.GetActiveScene().name != "load"&& SceneManager.GetActiveScene().name != "begining")
        {
            scen = SceneManager.GetActiveScene().buildIndex;
            scenname = SceneManager.GetActiveScene().name;
        }
        else
        {
            Ui.SetActive(false);
        }

        if (iscontinue)
        {
            if (SceneManager.GetActiveScene().buildIndex == scen)
            {
                Ui.SetActive(true);
                iscontinue = false;
            }
        }



    }

}
