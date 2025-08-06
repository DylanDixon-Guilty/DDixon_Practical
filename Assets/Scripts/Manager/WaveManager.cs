using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private float spawnIntervalMin = 1f;
    [SerializeField] private float spawnIntervalMax = 5f;
    [SerializeField] private int minEnemiesToSpawnPerWave = 1;
    [SerializeField] private int maxEnemiesToSpawnPerWave = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartWave();
    }

    private void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        int spawnPointIndex = Random.Range(0, spawnPoint.Length);
        int enemyToSpawnIndex = Random.Range(0, enemyPrefab.Length);
        GameObject enemyInstance = Instantiate(enemyPrefab[enemyToSpawnIndex], spawnPoint[spawnPointIndex].position, Quaternion.identity);
        enemyInstance.GetComponent<Enemy>().Initialized(playerPosition);
    }

    private void StartWave()
    {
        int numEnemiesToSpawn = Random.Range(minEnemiesToSpawnPerWave, maxEnemiesToSpawnPerWave);
        for(int i = 0; i < numEnemiesToSpawn; i++)
        {
            SpawnEnemy();
        }
        Invoke("StartWave", Random.Range(spawnIntervalMin, spawnIntervalMax));
    }
}
