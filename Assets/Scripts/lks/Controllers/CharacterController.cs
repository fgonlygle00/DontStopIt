using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Move
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
    }
}
