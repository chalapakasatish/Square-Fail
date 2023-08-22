using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        //if (target.tag == "Player")
        //{
        //    SoundManager.instance.DeathSound();
        //    GameManager.instance.GameFailed();
        //    GameManager.instance.gameState = GameState.FAILED;
        //}
    }
}
