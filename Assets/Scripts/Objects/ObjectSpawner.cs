using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval;
    private int maxSpawnObjectNumber;
    WaitForSeconds spawnWait;

    private void Awake()
    {
        maxSpawnObjectNumber = spawnPoints.Length;
        spawnWait = new WaitForSeconds(spawnInterval);
    }

    private void Start()
    {
        StartCoroutine(RepeatSpawn());
    }

    private int RandomSpawnNumber()
    {
        return Random.Range(0, maxSpawnObjectNumber + 1);
    }

    private List<int> GetSpawnPointIndices(int number)
    {
        if (number == 1)
        {
            return new List<int> { Random.Range(0, maxSpawnObjectNumber) };
        }

        List<int> indices = new List<int>(maxSpawnObjectNumber);
        for (int i = 0; i < maxSpawnObjectNumber; i++)
        {
            indices.Add(i);
        }

        for (int i = indices.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = indices[i];
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }

        return indices.GetRange(0, number);
    }

    private void Spawn()
    {
        int spawnNumber = RandomSpawnNumber();

        if (spawnNumber == 0)
        {
            return;
        }

        List<int> spawnPointIndices = GetSpawnPointIndices(spawnNumber);
        foreach (int index in spawnPointIndices)
        {
            ObjectPoolType objectPoolType = (ObjectPoolType)Random.Range(10, 13);
            GameObject obj = ObjectPoolManager.Instance.GetPoolObject(objectPoolType);
            obj.transform.position = spawnPoints[index].position;
        }
    }

    IEnumerator RepeatSpawn()
    {
        while (true)
        {
            Spawn();
            yield return spawnWait;
        }
    }
}
