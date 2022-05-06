using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int powerupCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(false), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        powerupCount = GameObject.FindGameObjectsWithTag("Powerup").Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave(++waveNumber);
            if(powerupCount == 0)
            {
                Instantiate(powerupPrefab, GenerateSpawnPosition(false), powerupPrefab.transform.rotation);
            }
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition(bool isEnemy = true)
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = 0;
        if (isEnemy)
        {
            spawnPosY = Random.Range(0, spawnRange);
        }
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        return randomPos;
    } 
}
