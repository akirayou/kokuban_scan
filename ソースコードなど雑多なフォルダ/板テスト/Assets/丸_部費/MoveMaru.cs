using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaru : MoveBase
{
    private Animator animator;
    public float speed = 2.0f;
    private float dx;
    private float vy = 0;
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
        speed=Random.Range(0.3f, 2.0f);
        //animator.SetFloat("walkSpeed", speed);
        animator.SetFloat("x",  (Seed % 4) / 5.0f + 0.2f) ;
        vy = 0;
        dx=Random.Range(-0.2f, 0.2f);

    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        float dt=Time.deltaTime;
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Walk"))
        {
            if (this.SpanFromBorn() > Setting.LifeTime) animator.SetTrigger("isExit");
            float x = animator.GetFloat("x");
            vy -= 0.25f * speed * dt;
            x += dx*dt;
            if (dx < 0)
            {
                if (x < 0)
                {
                    dx = Random.Range(0.01f, 0.3f);
                }
            }
            else
            {
                if (x > 1)
                {
                    dx = Random.Range(-0.3f, -0.01f);
                }
            }

            animator.SetFloat("x", x);
            float y = animator.GetFloat("y");
            y += vy*dt;

            if (vy>0)
            {
                if (0.6f<y)vy *= 0.5f;
                
            }
            else
            {
                if ( y <0.2f )
                {
                    vy = 0.5f * speed;
                }
            }
            animator.SetFloat("y", y);
        }

    }
}
