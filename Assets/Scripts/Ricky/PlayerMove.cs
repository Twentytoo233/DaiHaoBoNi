using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
     
    //*private float previousFramePosY;///记录上一帧y位置 判断是否播放下坠动画

    [SerializeField]
    private float MoveSpeed = 6f;
    [SerializeField]
    private float jumpForce = 10f;
    private float MoveH;
    private SpriteRenderer sp;
    [SerializeField]
    private bool isGrounded;
    private bool canDoubleJump;

    //private int jumpCount;

    public Transform checkPoint;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Vector2 checkBoxSize;

    [Header("Better Jump")]
    [SerializeField]
    private float fallFactor;//长跳跃系数
    [SerializeField]
    private float shortJumpFactor;

    private Animator anim;
    private bool isDead;

    [SerializeField]
    private bool getDaze;
    private bool rightDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = false;
        canDoubleJump = false;
    }

    void Update()
    {
        if (isGrounded)
        {
            MoveH = Input.GetAxis("Horizontal") * MoveSpeed;
            rightDir = MoveH >= 0 ? true : false;
            //if (MoveH == 0)
            //{
            //    //播放动画
            //    anim.Play("Idle");
            //}
            //else if (MoveH != 0 && anim.name != "Walk")
            //{
            //    //播放动画
            //    anim.SetTrigger("Walk");
            //}
        }
        else
        {
            if (rightDir)
                MoveH = Mathf.Max(Input.GetAxis("Horizontal") * MoveSpeed * 1.4f, -0.7f * MoveSpeed);
            else
                MoveH = Mathf.Min(Input.GetAxis("Horizontal") * MoveSpeed * 1.4f, 0.7f * MoveSpeed);
        }

        if (Mathf.Abs(MoveH) > 0.5f)
            anim.SetBool("isRun", true);
        else
            anim.SetBool("isRun", false);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && !anim.GetCurrentAnimatorStateInfo(0).IsName("fall"))
        {
            OnJump();
            canDoubleJump = true;

            //rb.velocity = Vector2.up * jumpForce;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
        {
            //OnDoubleJump();
            OnJump();
            canDoubleJump = false;
        }

        rb.velocity = new Vector2(MoveH, rb.velocity.y);
        //Debug.Log(MoveH);
        Flip();
        CheckGround();
        if (getDaze)
        {
            if (rb.gravityScale > 0)
            {
                rb.gravityScale = 0;
            }
            GetDaze();
        }
    }
    private void CheckGround()
    {
        Collider2D collider = Physics2D.OverlapBox(checkPoint.position, checkBoxSize, 0,layerMask);
        if (collider != null)
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(checkPoint.position, checkBoxSize);
    }
    private void Flip()
    {
        if (MoveH > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (MoveH < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    private void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallFactor * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * shortJumpFactor * Time.deltaTime;
        }
    }

    private void OnJump()
    {
        rb.velocity = Vector2.up * jumpForce;
        //播放跳跃动画
        anim.SetTrigger("Jump");
       
    }
    private void OnDoubleJump()
    {
        rb.velocity = Vector2.up * jumpForce * 0.8f;
        //播放跳跃动画
        anim.SetTrigger("Jump");
       
    }
    private void GetDaze()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed * 2.3f, Input.GetAxis("Vertical") * jumpForce);
        isGrounded = true;
        anim.SetBool("isGrounded", true);
        //if(dead)      
    }
}

