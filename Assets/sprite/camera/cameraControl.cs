using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public static bool hurt;
    private void Start()
    {
    }


    void FixedUpdate()
    {
        if (hurt)
        {
            GetComponent<Animator>().SetTrigger("shake");
            hurt = false;
        }
        transform.position =new Vector3(PlayerControler.position.x,PlayerControler.position.y,-10);
    }


}


