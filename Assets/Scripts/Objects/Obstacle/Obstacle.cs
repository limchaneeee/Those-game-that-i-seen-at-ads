using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ICollisionHandler
{
    public ObjectPoolType poolType;
    public int count;

    private void OnEnable()
    {
        int minCount = 1 * (1 + CharacterManager.Instance.Player.playerSO.playerCloneNumber);
        int maxCount = 20 * (1 + CharacterManager.Instance.Player.playerSO.playerCloneNumber);
        poolType = ObjectPoolType.ObstacleObject;
        count = Random.Range(minCount, maxCount);
    }

    public void OnBulletHit()
    {
        count--;

        if (count <= 0)
        {
            ObjectPoolManager.Instance.GetBackObject(gameObject, poolType);
        }
    }

    public void OnPlayerHit()
    {
        CharacterManager.Instance.Player.cloneSpawner.DecreasePlayerClone(count);
    }

    public void OnPlayerCloneHit(GameObject obj)
    {
        CharacterManager.Instance.Player.cloneSpawner.DeActivateClone(obj);
    }

    public void OnBottomWallHit()
    {
        ObjectPoolManager.Instance.GetBackObject(gameObject, poolType);
    }
}
