using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnRangeX = 8f;
    public float spawnPosY = 50f;
    public float spawnRangeZ = 94f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 50, Random.Range(0, spawnRangeZ));
            int enemyIndex = Random.Range(0, enemies.Length);
            Instantiate(enemies[enemyIndex], spawnPos, enemies[enemyIndex].transform.rotation);
        }
    }
}
