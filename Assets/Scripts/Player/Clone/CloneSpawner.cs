using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private int maxCloneNumber;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float minDistance;
    [SerializeField] private LayerMask collisionLayerMask;
    public List<GameObject> activeClones = new List<GameObject>();
    public int currentCloneNumber;

    private void Start()
    {
        playerPosition = CharacterManager.Instance.Player.gameObject.transform;
        activeClones.Capacity = maxCloneNumber;
        currentCloneNumber = 0;
    }

    public void IncreasePlayerClone(int amount)
    {
        if (currentCloneNumber + amount > maxCloneNumber)
        {
            amount = maxCloneNumber - currentCloneNumber;
        }
        currentCloneNumber += amount;

        for (int i = 0; i < amount; i++)
        {
            GameObject clone = ObjectPoolManager.Instance.GetPoolObject(ObjectPoolType.PlayerObject);
            if (clone != null)
            {
                Vector3 spawnPosition = GetValidSpawnPosition();
                clone.transform.position = spawnPosition;

                activeClones.Add(clone);
            }
        }
    }

    private Vector3 GetValidSpawnPosition()
    {
        int attempt = 10;
        while (attempt > 0)
        {
            Vector3 randomPosition = playerPosition.position + Random.insideUnitSphere * spawnRadius;
            randomPosition.y = playerPosition.position.y;

            Collider[] colliders = Physics.OverlapSphere(randomPosition, minDistance, collisionLayerMask);
            if (colliders.Length == 0)
            {
                return randomPosition;
            }
        }
        
        return new Vector3(0, 0, 10f);
    }

    public void DecreasePlayerClone(int amount)
    {
        if (currentCloneNumber == 0) return;

        currentCloneNumber = Mathf.Max(0, currentCloneNumber - amount);

        if (currentCloneNumber == 0)
        {
            ClearAllClones();
            return;
        }

        RemoveClones(amount);
    }

    private void ClearAllClones()
    {
        foreach (GameObject clone in activeClones)
        {
            ObjectPoolManager.Instance.GetBackObject(clone, ObjectPoolType.PlayerObject);
        }
        activeClones.Clear();
    }

    private void RemoveClones(int amount)
    {
        while (amount > 0 && activeClones.Count > 0)
        {
            GameObject clone = activeClones[activeClones.Count - 1];
            ObjectPoolManager.Instance.GetBackObject(clone, ObjectPoolType.PlayerObject);
            activeClones.RemoveAt(activeClones.Count - 1);
            amount--;
        }
    }

    public void DeActivateClone(GameObject obj)
    {
        if (!activeClones.Contains(obj))
        {
            return;
        }

        currentCloneNumber = Mathf.Max(0, currentCloneNumber - 1);
        activeClones.Remove(obj);
        ObjectPoolManager.Instance.GetBackObject(obj, ObjectPoolType.PlayerObject);
    }
}