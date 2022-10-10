using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalk : MoveBase
{
    private Animator animator;
    public float speed = 1.0f;
    enum GoDirc
    {
        Right,
        Left
    };
    private GoDirc dir;
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
        dir = GoDirc.Right;
        speed=Random.Range(0.3f, 2.0f);
        animator.SetFloat("walkSpeed", speed);
        animator.SetFloat("y", (Seed % 4) * 0.2f);


    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        float dt=Time.deltaTime;
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            if (this.SpanFromBorn() > Setting.LifeTime) animator.SetBool("isExit", true);

            float x = animator.GetFloat("x");
            if (dir == GoDirc.Right)
            {
                animator.SetBool("isRight", true);
                x += 0.2f*dt*speed;
                if (1<x)
                {
                    x = 1;
                    dir = GoDirc.Left;
                }
            }
            else
            {
                animator.SetBool("isRight", false);
                x -= 0.2f * dt*speed;
                if ( x <0 )
                {
                    x = 0;
                    dir = GoDirc.Right;
                }
            }
            animator.SetFloat("x", x);
        }

    }
}
