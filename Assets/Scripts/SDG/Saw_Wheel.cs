using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_Wheel : MonoBehaviour
{
    public float speed = 2f;

    private Death death;

    void Update()
    {
        MoveUp();
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jelly")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "player")
        {
            Destroy(collision.gameObject, 2f);
            if (death != null)
            {
                death.GameOver();
            }
        }
    }
}