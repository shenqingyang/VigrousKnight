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
        //����һ��ʱ�������
        Destroy(gameObject, lifetimer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //UI�����˶�
        transform.position += new Vector3(0, upspeed * Time.deltaTime, 0);
        
    }

    //��ʾ�˺���ֵ
    public void ShowDamageNum(float damage)
    {
        text.text = damage.ToString();
    }

    //����
    ////�����˺���ֵUI
    //damageNum damagable = Instantiate(damageNumUi, collision.gameObject.transform.position, Quaternion.identity).GetComponent<damageNum>();
    //damagable.ShowDamageNum(damage);
}
