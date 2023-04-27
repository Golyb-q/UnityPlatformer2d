using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float horizontalSpeed;
    public float verticalSpeed;
    private float horizontalMove;
    private float verticalMove;
    private Animator animator;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        if (horizontalMove != 0f)
        {
            rb2D.velocity = new Vector2(horizontalMove * horizontalSpeed, rb2D.velocity.y);
            if (horizontalMove > 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
            else
                transform.localScale = new Vector3(-1f, 1f, 1f);
            animator.SetBool("Walk", true);
        }
        else if (!animator.GetBool("Air"))
        {
            rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
        }
        if (verticalMove != 0f && canJump)
        {
            animator.SetBool("Air", true);
            rb2D.AddForce(new Vector2(0f, verticalMove * verticalSpeed), ForceMode2D.Impulse);
            canJump = false;
        }
        if (!(verticalMove != 0f && canJump) && !(horizontalMove != 0f))
        {
            animator.SetBool("Walk", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor")
        {
            animator.SetBool("Air", false);
            canJump = true;
        }
        Debug.Log("Enter: " + collision.gameObject.name + "; canJump: " + canJump);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit: " + collision.gameObject.name + "; canJump: " + canJump);
    }
}
