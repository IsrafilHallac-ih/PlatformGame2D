using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController: MonoBehaviour
{
   public  float moveSpeed;
    public Transform rightTarget, leftTarget;

    public float moveTime, waitTime;
    float moveCount, waitCount;

    bool right;

    public SpriteRenderer spriteRenderer;

    Rigidbody2D rigidbody2D;
    Animator anim;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        rightTarget.parent = null;
        leftTarget.parent = null;

        right = true;

        moveCount = moveTime;
    }

    
    void Update()
    {
        if (moveCount>0)
        {
            moveCount -= Time.deltaTime;
        

        if (right)
        {
            rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = true;
            if (transform.position.x>rightTarget.position.x)
            {
                right = false;
            }

        }
        else
        {
            rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = false;
            if (transform.position.x < leftTarget.position.x)
            {
                right = true;
            }

        }

            if (moveCount<=0)
            {
                waitCount = Random.Range(waitTime*0.5f,waitTime*1.2f);
            }
            anim.SetBool("hareketEdiyor", true);
        }
        else if (waitCount>0)
        {
            waitCount -= Time.deltaTime;
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);

            if (waitCount<0)
            {
                moveCount = Random.Range(moveTime*0.5f,moveTime*1.2f);
            }
            anim.SetBool("hareketEdiyor", false);
        }
    }
}
