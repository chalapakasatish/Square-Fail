using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    
    void Update()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;
        if (GameManager.instance.gameState == GameState.FAILED)
        {
            Destroy(gameObject);
        }
    }
}
