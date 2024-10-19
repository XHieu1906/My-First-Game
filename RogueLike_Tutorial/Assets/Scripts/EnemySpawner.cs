using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public int maxEnemies = 100;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    private int currentEnemyCount = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    void Update()
    {
        
    }
     private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            if (currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(spawnInterval); 
        }
    }
    private void SpawnEnemy(){
        Vector2 spawnPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        currentEnemyCount++;
    }
    public void DecreaseEnemyCount(){
    currentEnemyCount--;
    }

}
