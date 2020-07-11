using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captain : MonoBehaviour
{
    private float walkSpeed;
    private float curSpeed;

    public float playerspeed = 1;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    Rigidbody2D rb2d;
    
    private Vector3 mousePos;
    SpriteRenderer spr;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        walkSpeed = (float)(playerspeed);
    }

    void FixedUpdate()
    {
        curSpeed = walkSpeed;

        float hor = Input.GetAxis("Horizontal") * curSpeed;
        float vert = Input.GetAxis("Vertical") * curSpeed;
        float jump = Input.GetAxis("Jump");

        if(jump == 0)
        {
            animator.SetBool("crouch", false);

            if (vert != 0 || hor != 0)
            {
                animator.SetBool("moving", true);
            }
            else
            {
                animator.SetBool("moving", false);
            }

            rb2d.velocity = new Vector2(Mathf.Lerp(0, hor, 0.8f),
                                                 Mathf.Lerp(0, vert, 0.8f));
        } else
        {
            animator.SetBool("moving", false);
            animator.SetBool("crouch", true);
            rb2d.velocity = new Vector2(0,0);
        }

        //MouseLook Stuff
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        if (angle > 0)
        {
            animator.SetBool("lookup", true);
        }
        else
        {
            animator.SetBool("lookup", false);
        }

        if (angle > 90 || angle < -90)
        {
            spr.flipX = true;

            if(hor > 1)
            {
                animator.SetFloat("runspeed", -1);
            } else
            {
                animator.SetFloat("runspeed", 1);
            }
            
        }
        else
        {
            spr.flipX = false;

            if (hor < 1)
            {
                animator.SetFloat("runspeed", -1);
            }
            else
            {
                animator.SetFloat("runspeed", 1);
            }
        }

    }

    public void Hit()
    {
        animator.SetTrigger("hit");
    }
}