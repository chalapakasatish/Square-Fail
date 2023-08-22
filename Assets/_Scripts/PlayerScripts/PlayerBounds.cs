using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float minX = -2.6f, maxX = 2.6f, minY = -5.6f,maxY = 4f;
    bool outOfBounds;
    public GameObject shield;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
    private void Update()
    {
        //CheckBounds();
    }
    private void LateUpdate()
    {
        if (GameManager.instance.gameState == GameState.PLAYING)
        {
            Vector3 viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
            transform.position = viewPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shield")
        {
            shield.SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Coin")
        {
            CurrencyManager.instance.AddCoinBalance(1);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "TopSpikes")
        {
            Time.timeScale = 0;
            SoundManager.instance.DeathSound();
            GameManager.instance.GameFailed();
            //GameManager.instance.gameState = GameState.FAILED;
        }
        if (collision.tag == "Enemy")
        {
            if(shield.activeInHierarchy)
            {
                shield.SetActive(false);
                Destroy(collision.gameObject);
            }else
            {
                Time.timeScale = 0;
                SoundManager.instance.DeathSound();
                GameManager.instance.GameFailed();
                //GameManager.instance.gameState = GameState.FAILED;
            }
        }
    }
    //private void CheckBounds()
    //{
    //    Vector2 temp = transform.position;
    //    //if (temp.x > maxX)
    //    //{
    //    //    temp.x = maxX;
    //    //}
    //    //if (temp.x < minX)
    //    //{
    //    //    temp.x = minX;
    //    //}

    //    transform.position = temp;

    //    if (temp.y <= minY)
    //    {
    //        if (!outOfBounds)
    //        {
    //            outOfBounds = true;
    //            SoundManager.instance.DeathSound();
    //            GameManager.instance.GameFailed();
    //        }
    //    }

    //}

}
