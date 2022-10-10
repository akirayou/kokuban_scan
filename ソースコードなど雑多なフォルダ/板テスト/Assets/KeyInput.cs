using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    public SystemMessage mes;
    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            mes.echo("�����ݒ�  " + (Setting.LifeTime / 60).ToString() + "��\n" +
                "1:10�b\n" +
                "2:1��\n" +
                "3:2��\n" +
                "4:4��\n" +
                "5:8��\n" +
                "9: �Y�[���A�E�g\n" +
                "0:�@�Y�[���C��");
        }
        if (Input.GetKey(KeyCode.Alpha1)) { Setting.LifeTime = 10; mes.echo("�����ݒ�  " + (Setting.LifeTime / 60).ToString() + "min"); }
        if (Input.GetKey(KeyCode.Alpha2)) { Setting.LifeTime = 1 * 60; mes.echo("�����ݒ�  " + (Setting.LifeTime / 60).ToString() + "min"); }
        if (Input.GetKey(KeyCode.Alpha3)) {Setting.LifeTime = 2 * 60;mes.echo("�����ݒ�  " + (Setting.LifeTime / 60).ToString() + "min"); }
        if (Input.GetKey(KeyCode.Alpha4)) {Setting.LifeTime = 4 * 60; mes.echo("�����ݒ�  " + (Setting.LifeTime / 60).ToString() + "min"); }
        if (Input.GetKey(KeyCode.Alpha5)) {Setting.LifeTime = 8 * 60; mes.echo("�����ݒ�  " + (Setting.LifeTime / 60).ToString() + "min"); }
        if (Input.GetKeyDown(KeyCode.Alpha9)) mainCam.orthographicSize *= 1.2f ;
        if (Input.GetKeyDown(KeyCode.Alpha0)) mainCam.orthographicSize /= 1.2f;



    }
}
