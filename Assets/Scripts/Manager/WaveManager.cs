using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public struct SpawnData
{
    public GameObject Enemy;
    public float TimeBeforeSpawn;
    public Transform SpawnPoint;
    public Transform PlayerPosition;
}

[System.Serializable]
public struct WaveData
{
    public float TimeBeforeWave;
    public List<SpawnData> EnemyData;
}
public class WaveManager : MonoBehaviour
{
    public List<WaveData> waves;
    public float EnemySpawnTime = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(ContinouslySpawnEnemy), EnemySpawnTime, EnemySpawnTime);
    }

    IEnumerator WaveStart()
    {
        foreach (WaveData currentWave in waves)
        {
            foreach (SpawnData currentEnemyToSpawn in currentWave.EnemyData)
            {
                yield return new WaitForSeconds(currentEnemyToSpawn.TimeBeforeSpawn);
                SpawnEnemies(currentEnemyToSpawn.Enemy, currentEnemyToSpawn.SpawnPoint, currentEnemyToSpawn.PlayerPosition);
            }
        }
    }

    public void SpawnEnemies(GameObject enemyPrefab, Transform spawnPoint, Transform endPoint)
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemyStats enemy = enemyInstance.GetComponent<EnemyStats>();
        enemy.Initialized(endPoint);
    }

    private void ContinouslySpawnEnemy()
    {
        StartCoroutine(WaveStart());
    }
}
