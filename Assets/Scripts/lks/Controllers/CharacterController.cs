using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed;
    public float jumpSpeed;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //jump
        if (Input.GetButtonUp("Jump") && !animator.GetBool("isJump"))
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
        }

            //friction force
            if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector2(0.5f * rb.velocity.normalized.x, rb.velocity.y);
        }

        //change direction
        if(Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //state change
        if(Mathf.Abs(rb.velocity.normalized.x) < 0.5)
        {
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
        }
    }

    void FixedUpdate()
    {
        //move
        float x = Input.GetAxisRaw("Horizontal");

        rb.AddForce(Vector2.right * x, ForceMode2D.Impulse);

        if(rb.velocity.x > maxSpeed) //right
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else if(rb.velocity.x < maxSpeed*(-1)) //left
        {
            rb.velocity = new Vector2(maxSpeed*(-1), rb.velocity.y);
        }

        //jump landing
        if(rb.velocity.y < 0)
        {
            Debug.DrawRay(rb.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    animator.SetBool("isJump", false);
                }
            }
        }
    }
}
