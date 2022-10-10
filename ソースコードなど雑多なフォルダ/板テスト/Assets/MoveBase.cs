using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public int Seed { get; set; }
    private float BornTime;
    protected void Start()
    {
        BornTime = Time.realtimeSinceStartup;
    }
    public float SpanFromBorn()
    {
        return Time.realtimeSinceStartup-BornTime; 
    }
    
    public virtual void SeTexture(Texture2D _tex)
    {
        var mat =GetComponentInChildren<Renderer>().material;

        mat.mainTexture = _tex;
    }

}
