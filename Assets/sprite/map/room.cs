using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
    public GameObject passageup, passagedown, passageleft, passageright;
    public bool up,down,left,right;
    public int step;
    public int passagenum;
    // Start is called before the first frame update
    void Start()
    {
        passagedown.SetActive(down);
        passageleft.SetActive(left);
        passageright.SetActive(right);
        passageup.SetActive(up);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRoom()
    {
        step = (int)(Mathf.Abs(transform.position.x / roomgenerator.x + Mathf.Abs(transform.position.y / roomgenerator.y)));

        if (up)
            passagenum++;
        if (down)
            passagenum++;
        if (left)
            passagenum++;
        if (right)
            passagenum++;

    }

}
