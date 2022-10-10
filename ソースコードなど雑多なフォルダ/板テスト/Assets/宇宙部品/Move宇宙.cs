using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move‰F’ˆ : MoveBase
{
    private Animator animator;
    public float speed = 2.0f;
    enum GoDirc
    {
        Up,
        Down
    };
    private GoDirc dir;
    private float dx;
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
        dir = GoDirc.Up;
        speed=Random.Range(0.3f, 2.0f);
        //animator.SetFloat("walkSpeed", speed);
        animator.SetFloat("x",  (Seed % 4) / 5.0f + 0.2f) ;

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
            if (dir == GoDirc.Up)
            {
                animator.SetBool("isUp", true);
                y += 0.2f*dt*speed*0.5f;
                if (1<y)
                {
                    y = 1;
                    dir = GoDirc.Down;
                }
            }
            else
            {
                animator.SetBool("isUp", false);
                y -= 0.2f * dt*speed;
                if ( y <0.3f )
                {
                    y = 0.3f;
                    dir = GoDirc.Up;
                }
            }
            animator.SetFloat("y", y);
        }

    }
}
