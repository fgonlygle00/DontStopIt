using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_Wheel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jelly")
        {
            Destroy(collision.gameObject);
        }
    }
}