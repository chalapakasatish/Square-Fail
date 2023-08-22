using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchControls : MonoBehaviour
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
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            isGrounded = Physics2D.OverlapCircle(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, checkRadius, whatIsGround);
        }
        if(GameManager.instance.gameState == GameState.FAILED)
        {
            moveRight = false;
            moveLeft = false;
            isJump = false;
        }
    }
    private void FixedUpdate()
    {
        if(GameManager.instance.gameState == GameState.PLAYING)
        Move();
    }
    public void Move()
    {
        if (Input.GetAxis("Horizontal") > 0 || moveRight)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * Time.deltaTime, GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        if (Input.GetAxis("Horizontal") < 0 || moveLeft)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed * Time.deltaTime, GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true || isJump && isGrounded == true && jumpCount == 0)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce * Time.deltaTime;
            }
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
