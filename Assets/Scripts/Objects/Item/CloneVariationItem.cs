using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CloneVariationType
{
    SubstractAdd,
    DivideMultiply,
    COUNT
}


public class CloneVariationItem : MonoBehaviour, ICollisionHandler
{
    public UIObjectCount uiCount;
    public ObjectPoolType poolType;
    public CloneVariationType type;
    public int count;

    private void OnEnable()
    {
        Initialize();
        uiCount.UpdateCountUI(count, type);
    }

    private void Initialize()
    {
        int minCount = 1 * (1 + CharacterManager.Instance.Player.playerSO.playerCloneNumber);
        int maxCount = 5 * (1 + CharacterManager.Instance.Player.playerSO.playerCloneNumber);
        count = Random.Range(minCount, maxCount) * -1;
        poolType = ObjectPoolType.CloneVariationItemObject;
        type = (CloneVariationType)Random.Range(0, (int)CloneVariationType.COUNT);
    }

    public void OnBulletHit()
    {
        count++;

        uiCount.UpdateCountUI(count, type);
    }

    public void OnPlayerHit()
    {
        if (type == CloneVariationType.SubstractAdd)
        {
            if (count > 0)
            {
                CharacterManager.Instance.Player.cloneSpawner.IncreasePlayerClone(count);
            }
            else if (count < 0)
            {
                count *= -1;
                CharacterManager.Instance.Player.cloneSpawner.DecreasePlayerClone(count);
            }
        }
        else if (type == CloneVariationType.DivideMultiply)
        {
            if (count < 0)
            {
                count *= -1;
                int amount = CharacterManager.Instance.Player.playerSO.playerCloneNumber * (1 - (1 / count));
                CharacterManager.Instance.Player.cloneSpawner.DecreasePlayerClone(amount);
            }
            else if (count > 0)
            {
                int amount = CharacterManager.Instance.Player.playerSO.playerCloneNumber * (count - 1);
                CharacterManager.Instance.Player.cloneSpawner.IncreasePlayerClone(amount);
            }
        }

        ObjectPoolManager.Instance.GetBackObject(gameObject, ObjectPoolType.CloneVariationItemObject);
    }

    public void OnPlayerCloneHit(GameObject obj)
    {
        return;
    }

    public void OnBottomWallHit()
    {
        ObjectPoolManager.Instance.GetBackObject(gameObject, poolType);
    }
}
