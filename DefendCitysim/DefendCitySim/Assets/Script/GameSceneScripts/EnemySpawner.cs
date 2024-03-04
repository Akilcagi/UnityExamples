using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [System.Serializable]
    public class EnemyInfo
    {
        public GameObject enemyPrefab;
        public int count;
        public float spawnInterval;
    }

    [System.Serializable]
    public class EnemyWave
    {
        public List<EnemyInfo> enemies;
        public float waveInterval;
    }

    public List<EnemyWave> waves;
    public Transform[] spawnPoints;
    private int currentWaveIndex = 0;
    public Tower tower;

    [System.Obsolete]
    void Start()
    {
        tower = FindObjectOfType<Tower>();
        if (tower == null)
        {
            Debug.LogError("Tower not found in the scene.");
            return;
        }
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int waveIndex = 0; waveIndex < waves.Count; waveIndex++)
        {
            yield return StartCoroutine(SpawnWave(waves[waveIndex]));
        }
    }

    IEnumerator SpawnWave(EnemyWave wave)
    {
        foreach (var enemyInfo in wave.enemies)
        {
            for (int i = 0; i < enemyInfo.count; i++)
            {
                if (spawnPoints.Length == 0)
                {
                    Debug.LogError("Spawn points not set.");
                    yield break;
                }
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(enemyInfo.enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(enemyInfo.spawnInterval);
            }
        }
        yield return new WaitForSeconds(wave.waveInterval);
    }
   

}



