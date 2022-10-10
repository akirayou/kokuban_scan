using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MoveBase
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
        dx=Random.Range(0.2f, 0.4f);
        dx *= 1-Random.Range(0, 1) * 2;
        animator.SetFloat("y", Random.Range(0.3f, 0.8f));
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
            if (this.SpanFromBorn() > Setting.LifeTime ) animator.SetTrigger("isExit");
            float x = animator.GetFloat("x");
            vy -= 0.1f * speed * dt;
            x += dx*dt;
            if (dx < 0)
            {
                if (x < 0)
                {
                    animator.SetBool("isRight",true);
                    dx = Random.Range(0.1f, 0.3f);
                }
            }
            else
            {
                if (x > 1)
                {
                    animator.SetBool("isRight", false);
                    dx = Random.Range(-0.1f, -0.2f);
                }
            }

            animator.SetFloat("x", x);
        }

    }
}
