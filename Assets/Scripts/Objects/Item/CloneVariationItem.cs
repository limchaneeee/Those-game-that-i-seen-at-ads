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
    public UIObjectInfo uiInfo;
    public UIObjectCount uiCount;
    public ObjectPoolType poolType;
    public CloneVariationType type;
    public int count;
    private int variationValue;

    private void OnEnable()
    {
        Initialize();
        uiInfo.UpdateInfo(type, variationValue);
        uiCount.UpdateCountUI(count, type);
    }

    private void Initialize()
    {
        poolType = ObjectPoolType.CloneVariationItemObject;
        type = SetCloneVariationType();
        SetCountValue();
        variationValue = CalculateVariationValue();
    }

    private CloneVariationType SetCloneVariationType()
    {
        int randomValue = Random.Range(1, 101);
        if (randomValue < 20)
        {
            return CloneVariationType.DivideMultiply;
        }
        return CloneVariationType.SubstractAdd;
    }

    private void SetCountValue()
    {
        int minCount = 5 * (1 + CharacterManager.Instance.Player.cloneSpawner.currentCloneNumber);
        int maxCount = 10 * (1 + CharacterManager.Instance.Player.cloneSpawner.currentCloneNumber);
        count = Random.Range(minCount, maxCount) * -1;
    }

    public void OnBulletHit()
    {
        count++;

        variationValue = CalculateVariationValue();

        uiCount.UpdateCountUI(count, type);
        uiInfo.UpdateInfo(type, variationValue);
    }

    public void OnPlayerHit()
    {
        if (type == CloneVariationType.SubstractAdd)
        {
            if (variationValue > 0)
            {
                CharacterManager.Instance.Player.cloneSpawner.IncreasePlayerClone(variationValue);
            }
            else if (variationValue < 0)
            {
                variationValue *= -1;
                CharacterManager.Instance.Player.cloneSpawner.DecreasePlayerClone(variationValue);
            }
        }
        else if (type == CloneVariationType.DivideMultiply)
        {
            if (variationValue < 0)
            {
                variationValue *= -1;
                int amount = (int)((1 - (1.0f / variationValue)) * CharacterManager.Instance.Player.cloneSpawner.currentCloneNumber);
                CharacterManager.Instance.Player.cloneSpawner.DecreasePlayerClone(amount);
            }
            else if (variationValue > 0)
            {
                int amount = (variationValue - 1) * CharacterManager.Instance.Player.cloneSpawner.currentCloneNumber;
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

    public int CalculateVariationValue()
    {
        int value = 0;
        if (type == CloneVariationType.SubstractAdd)
        {
            value = count / 10;
            if (count % 10 >= 0) value += 1;
            else value -= 1;
            value = Mathf.Clamp(value, -30, 30);
        }
        else if (type == CloneVariationType.DivideMultiply)
        {
            value = count / 30;
            if (count % 30 >= 0) value += 2;
            else value -= 2;
            value = Mathf.Clamp(value, -10, 5);
        }

        return value;
    }

}