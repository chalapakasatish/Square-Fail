using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myBody;
    public float moveSpeed = 1f;
    private bool moveRight;
    private bool moveLeft;

    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    private bool isJump;
    public int jumpCount = 0;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.gameState == GameState.PLAYING)
            Move();
    }
    public void Move()
    {
        if(Input.GetAxis("Horizontal") > 0 || moveRight)
        {
            myBody.velocity = new Vector2(moveSpeed * Time.deltaTime, myBody.velocity.y);
        }
        if (Input.GetAxis("Horizontal") < 0 || moveLeft)
        {
            myBody.velocity = new Vector2(-moveSpeed * Time.deltaTime, myBody.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true || isJump && isGrounded == true && jumpCount == 0)
        {
            myBody.velocity = Vector2.up * jumpForce * Time.deltaTime;
            jumpCount = 1;
        }
    }
    
    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x * Time.deltaTime, myBody.velocity.y);
    }
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }
    public void PointerDownJump()
    {
        isJump = true;
        jumpCount = 0;
    }
    public void PointerUpJmup()
    {
        isJump = false;
    }

}
