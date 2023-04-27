using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float horizontalSpeed;
    public float verticalSpeed;
    private float horizontalMove;
    private float verticalMove;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        if (horizontalMove != 0f || verticalMove != 0f)
            rb2D.AddForce(new Vector2(horizontalMove * horizontalSpeed, verticalMove * verticalSpeed), ForceMode2D.Impulse);
    }
}
