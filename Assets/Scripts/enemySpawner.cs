using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnRangeX = 2f;
    public float spawnPosY = 50f;
    public float spawnRangeZ = 94f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());   //FUncion con una Coroutine que hace que pase X tiempo para que se vuelva a ejecutar la funcion
    }

    IEnumerator SpawnEnemy()        // Funcion que Spawnea los enemigos en un rango de distancia cada 1 a 3 segundos
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
