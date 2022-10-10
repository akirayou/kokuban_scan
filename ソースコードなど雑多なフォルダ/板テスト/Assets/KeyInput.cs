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
            mes.echo("寿命設定  " + (Setting.LifeTime / 60).ToString() + "分\n" +
                "1:10秒\n" +
                "2:1分\n" +
                "3:2分\n" +
                "4:4分\n" +
                "5:8分\n" +
                "9: ズームアウト\n" +
                "0:　ズームイン");
        }
        if (Input.GetKey(KeyCode.Alpha1)) { Setting.LifeTime = 10; mes.echo("寿命設定  " + (Setting.LifeTime / 60).ToString() + "min"); }
        if (Input.GetKey(KeyCode.Alpha2)) { Setting.LifeTime = 1 * 60; mes.echo("寿命設定  " + (Setting.LifeTime / 60).ToString() + "min"); }
        if (Input.GetKey(KeyCode.Alpha3)) {Setting.LifeTime = 2 * 60;mes.echo("寿命設定  " + (Setting.LifeTime / 60).ToString() + "min"); }
        if (Input.GetKey(KeyCode.Alpha4)) {Setting.LifeTime = 4 * 60; mes.echo("寿命設定  " + (Setting.LifeTime / 60).ToString() + "min"); }
        if (Input.GetKey(KeyCode.Alpha5)) {Setting.LifeTime = 8 * 60; mes.echo("寿命設定  " + (Setting.LifeTime / 60).ToString() + "min"); }
        if (Input.GetKeyDown(KeyCode.Alpha9)) mainCam.orthographicSize *= 1.2f ;
        if (Input.GetKeyDown(KeyCode.Alpha0)) mainCam.orthographicSize /= 1.2f;



    }
}
