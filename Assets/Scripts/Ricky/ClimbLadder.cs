using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    private float vertical; // 垂直输入
    private float speed = 3f; // 爬梯子的速度
    private bool isLadder;
    private bool isClimbing;

    private Animator anim;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        isClimbing = false;  // 初始时不处于攀爬状态
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Input.GetKey(KeyCode.W) && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
            anim.SetBool("Climbing", true);
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            anim.SetBool("Climbing", false);
            // 播放 Idle 动画
            anim.Play("Idle");
        }
    }
}
