using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platformSpawnTimer;
    float currentPlatformSpawnTimer;

    int platformSpawnCount;

    public float minX = -2f, maxX = 2f;

    public GameObject shield;
    public float shieldSpawnTime;
    public float curentShieldSpawnTime;
    void Start()
    {
        currentPlatformSpawnTimer = shieldSpawnTime;
        
    }
    void Update()
    {
        if (GameManager.instance.gameState == GameState.PLAYING)
        {
            SpawnPlatforms();
            if (curentShieldSpawnTime >= shieldSpawnTime)
            {
                ShieldSpawn();
                shieldSpawnTime = 50;
            }
            else
            {
                shieldSpawnTime -= Time.deltaTime;
            }
        }
        if (GameManager.instance.gameState == GameState.FAILED)
        {
            shieldSpawnTime = 20;
        }
    }
    public void ShieldSpawn()
    {
        Instantiate(shield,transform.position, Quaternion.identity);
    }

    public void SpawnPlatforms()
    {
        currentPlatformSpawnTimer += Time.deltaTime;
        if(currentPlatformSpawnTimer >= platformSpawnTimer)
        {
            platformSpawnCount++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            GameObject newPlatform = null;

            if(platformSpawnCount < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if(platformSpawnCount == 2)
            {
                if(Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }else
                {
                    newPlatform = Instantiate
                        (movingPlatforms[Random.Range(0,movingPlatforms.Length)],
                        temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }
                platformSpawnCount = 0;
            }

            if(newPlatform)
            newPlatform.transform.parent = this.transform;
            currentPlatformSpawnTimer = 0;
        }
    }
}
