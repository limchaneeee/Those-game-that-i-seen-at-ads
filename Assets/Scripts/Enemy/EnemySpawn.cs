using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2f;

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
        Vector3 spawnPosition = new Vector3(Random.Range(-3.6f, 3.6f), 0f, 34f);

        GameObject enemy = ObjectPoolManager.Instance.GetPoolObject(ObjectPoolType.EnemyObject);
        enemy.transform.position = spawnPosition;
        enemy.SetActive(true);
    }
}
