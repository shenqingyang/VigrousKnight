using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageNum : MonoBehaviour
{
    public Text text;
    public float lifetimer;
    public float upspeed;
    // Start is called before the first frame update
    void Start()
    {
        //经过一段时间后销毁
        Destroy(gameObject, lifetimer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //UI向上运动
        transform.position += new Vector3(0, upspeed * Time.deltaTime, 0);
        
    }

    //显示伤害数值
    public void ShowDamageNum(float damage)
    {
        text.text = damage.ToString();
    }

    //调用
    ////生成伤害数值UI
    //damageNum damagable = Instantiate(damageNumUi, collision.gameObject.transform.position, Quaternion.identity).GetComponent<damageNum>();
    //damagable.ShowDamageNum(damage);
}
