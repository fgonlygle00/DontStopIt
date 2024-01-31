using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabsCharacter;

    public float maxSpeed;
    public float jumpSpeed;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    CapsuleCollider2D cc;

    int playerLayer, platformLayer;
    int OnHitLayer;
    
    private void Awake()
    {
        for (int i = 0; i < _prefabsCharacter.Length; i++)
        {
            if (_prefabsCharacter[i].name == PlayerPrefs.GetString("FinalCharacter"))
            {
                Instantiate(_prefabsCharacter[i], transform);
                break;
            }
        }

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        cc = GetComponent<CapsuleCollider2D>();


        playerLayer = LayerMask.NameToLayer("player");
        OnHitLayer = LayerMask.NameToLayer("OnHit");
        platformLayer = LayerMask.NameToLayer("platform");
    }
    void Update()
    {
        //move
        float x = Input.GetAxisRaw("Horizontal");

        rb.AddForce(Vector2.right * x, ForceMode2D.Impulse);

        if (rb.velocity.x > maxSpeed) //right
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < maxSpeed * (-1)) //left
        {
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y);
        }

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
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //state change
        if (Mathf.Abs(rb.velocity.normalized.x) < 0.5)
        {
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jelly")
        {
            Destroy(collision.gameObject);
            OnHit(collision.transform.position);
            OnHit2(gameObject.transform.localScale);
            //Debug.Log("플레이어가 맞았습니다");
        }
        //if(collision.gameObject.tag == "")
        //{
        //    Destroy(gameObject);  
        //}
    }

    //플레이어가 맞았을 시
    void OnHit(Vector2 targetPos)
    {
        if(gameObject.layer != 9)
        {
            gameObject.layer = 9;

            spriteRenderer.color = new Color(1, 1, 1, 0.4f);

            maxSpeed = Mathf.Max(0.0f, maxSpeed - 0.5f);
            jumpSpeed = Mathf.Max(0.0f, jumpSpeed - 2);

            int dir = transform.position.x - targetPos.x > 0 ? 1 : -1;
            rb.AddForce(new Vector2(dir, 1) * 5, ForceMode2D.Impulse);

            Invoke("NoDamage", 1);
        }
    }

    void OnHit2(Vector3 targetSca)
    {
        transform.localScale = targetSca + new Vector3(0.1f, 0, 0);
        cc.size += new Vector2(0.01f, 0);

        //Physics2D.SyncTransforms();
    }

    void NoDamage()
    {
        gameObject.layer = 6;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void FixedUpdate()
    {
        //jump collision ignore
        if (rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
            Physics2D.IgnoreLayerCollision(OnHitLayer, platformLayer, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
            Physics2D.IgnoreLayerCollision(OnHitLayer, platformLayer, false);
        }

        //jump landing
        if (rb.velocity.y < 0)
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