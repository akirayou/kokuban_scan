using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStar : MoveBase
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
        speed=Random.Range(0.2f, 1.0f);
        //animator.SetFloat("walkSpeed", speed);
        animator.SetFloat("x",  (Seed % 4) / 5.0f + 0.2f) ;
        vy = 0;
        dx=Random.Range(0.2f, 0.4f);
        dx *= 1-Random.Range(0, 1) * 2;
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
            float y = animator.GetFloat("y");
            if (this.SpanFromBorn() > Setting.LifeTime && 0.3f<y && y<0.7f) animator.SetTrigger("isExit");
            float x = animator.GetFloat("x");
            vy -= 0.1f * speed * dt;
            x += dx*dt;
            if (dx < 0)
            {
                if (x < 0)
                {
                    dx = Random.Range(0.2f, 0.3f);
                }
            }
            else
            {
                if (x > 1)
                {
                    dx = Random.Range(-0.4f, -0.2f);
                }
            }

            animator.SetFloat("x", x);
            y += vy*dt;

            if ( y <0.0f )
            {
                y = 1;
                vy = 0;
            }
            animator.SetFloat("y", y);
        }

    }
}
