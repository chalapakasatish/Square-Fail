using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public static PlatformScript instance;
    private float moveSpeed;
    public float boundY = 6f;
    public bool movingPlatformLeft, movingPlatformRight, isBreakable, isSpike, isPlatform;
    Animator anim; 
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        if(isBreakable)
        {
            anim = GetComponent<Animator>();
        }
    }
    void Update()
    {
        if(GameManager.instance.gameState == GameState.PLAYING)
            Move();
        if (GameManager.instance.gameState == GameState.FAILED)
        {
            Destroy(gameObject);
        }
    }
    public  void DestroyPlatforms()
    {
        gameObject.SetActive(false);
    }
    private void Move()
    {
        Vector2 temp = transform.position;
        if (GameManager.instance.Score < 1000)
        {
            moveSpeed = 1.15f;
        }
        else if(GameManager.instance.Score >=1000 && GameManager.instance.Score <= 2000)
        {
            moveSpeed = 1.2f;
        }
        else if (GameManager.instance.Score >= 2000 && GameManager.instance.Score <= 3000)
        {
            moveSpeed = 1.25f;
        }
        else if (GameManager.instance.Score >= 3000 && GameManager.instance.Score <= 4000)
        {
            moveSpeed = 1.3f;
        }
        else if (GameManager.instance.Score >= 4000 && GameManager.instance.Score <= 5000)
        {
            moveSpeed = 1.35f;
        }
        else if (GameManager.instance.Score >= 5000 && GameManager.instance.Score <= 6000)
        {
            moveSpeed = 1.4f;
        }
        else if (GameManager.instance.Score >= 6000)
        {
            moveSpeed = 1.45f;
        }
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;
        if(temp.y >= boundY)
        {
            Destroy(gameObject);
        }
    }
    void BreakableDeactivate()
    {
        Invoke("BreakableDeactivateGameobject", 0.7f);
    }
    void BreakableDeactivateGameobject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            if(isSpike)
            {
                Destroy(target.gameObject);
                SoundManager.instance.GameOverSound();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            if(isBreakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }
            if (isPlatform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }
    private void OnCollisionStay2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            if(movingPlatformLeft)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-70f);
            }
            if (movingPlatformRight)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(70f);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (movingPlatformLeft)
            {
                target.gameObject.GetComponent<PlayerMovement>().GetComponent<Rigidbody2D>().velocity
                    = new Vector2(0, target.gameObject.GetComponent<PlayerMovement>().GetComponent<Rigidbody2D>().velocity.y);

            }
            if (movingPlatformRight)
            {
                target.gameObject.GetComponent<PlayerMovement>().GetComponent<Rigidbody2D>().velocity
                    = new Vector2(0, target.gameObject.GetComponent<PlayerMovement>().GetComponent<Rigidbody2D>().velocity.y);

            }
        }
    }
}
