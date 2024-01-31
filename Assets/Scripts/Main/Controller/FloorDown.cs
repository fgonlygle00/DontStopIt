using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FloorDown : MonoBehaviour
{
    [SerializeField] float fallsec = 0.1f, destroysec = 5f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == ("MainSprite"))
        {
            Invoke("platformdown", fallsec);
            Destroy(gameObject, destroysec);
        }
    }

    void platformdown()
    {
        rb.isKinematic = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
