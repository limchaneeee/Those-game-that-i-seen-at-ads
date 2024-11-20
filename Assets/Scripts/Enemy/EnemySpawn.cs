using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private Vector2 spawnXRange = new Vector2(-3.6f, 3.6f); 
    [SerializeField] private float spawnZ = 34f;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemies());
    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = ObjectPoolManager.Instance.GetPoolObject(ObjectPoolType.EnemyObject);

        Vector3 spawnPosition = new Vector3(Random.Range(spawnXRange.x, spawnXRange.y), 0f, spawnZ);
        enemy.transform.position = spawnPosition;

    }
}
