using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMessage : MonoBehaviour
{
    
    UnityEngine.UI.Text text;
    float lifetime = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<UnityEngine.UI.Text>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (0< lifetime)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0) text.text = "";
        }
    }
    public void echo(string s)
    {
        text.text = s;
        lifetime = 3;
    }
}
