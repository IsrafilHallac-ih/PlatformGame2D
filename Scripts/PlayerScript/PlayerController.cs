using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpPower;

    bool twoJump;
    bool directionRight;

    bool ground;
    public Transform groundControlPoint;
    public LayerMask groundLayer;

    public float recoilTime, recoilPower;
    float recoilCount;
    public float jump2X;

    Rigidbody2D rigidbody2D;
    Animator anim;

    public bool MoveStop;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        MoveStop = true;
    }

    private void Update()
    {
        if (MoveStop)
        {
            if (recoilCount <= 0)
            {
                PlayerMove();
                JumpFNC();
                ChangeDirectionFnc();
            }
            else
            {
                recoilCount -= Time.deltaTime;
                if (directionRight)
                {
                    rigidbody2D.velocity = new Vector2(-recoilPower, rigidbody2D.velocity.y);
                }
                else
                {
                    rigidbody2D.velocity = new Vector2(recoilPower, rigidbody2D.velocity.y);
                }

            }

            anim.SetFloat("moveSpeed", Mathf.Abs(rigidbody2D.velocity.x));
            anim.SetBool("ground", ground);
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
            anim.SetFloat("moveSpeed", Mathf.Abs(rigidbody2D.velocity.x));
        }

        
    }

    void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float speed = h * moveSpeed;

        rigidbody2D.velocity = new Vector2(speed , rigidbody2D.velocity.y);
    }

    void JumpFNC()
    {
        ground = Physics2D.OverlapCircle(groundControlPoint.position, .2f, groundLayer);
        if (ground)
        {
            twoJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (ground)
            {
               rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
                SoundController.instance.SoundEffects(3);
            }
            else
            {
                if (twoJump)
                {
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
                    twoJump = false;
                    SoundController.instance.SoundEffects(3);
                }
            }
            
        }
        
    }

   void ChangeDirectionFnc()
    {
        Vector2 temporaryScale = transform.localScale;
        if (rigidbody2D.velocity.x>0)
        {
            directionRight = true;
            temporaryScale.x = 1f;
        }
        else if (rigidbody2D.velocity.x<0)
        {
            directionRight = false;
            temporaryScale.x = -1f;
        }
        transform.localScale = temporaryScale;
    }

    public void Recoil()
    {
        
        recoilCount = recoilTime;
        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);

        anim.SetTrigger("damage");
    }

    public void Jump2XFNC()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jump2X);
        SoundController.instance.SoundEffects(3);
    }
}
