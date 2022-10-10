using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{

    void DestoryParent()
    {
        Destroy(this.transform.parent.gameObject);
    }
    void DestoryMe()
    {
        Destroy(this.transform.gameObject);
    }
}
