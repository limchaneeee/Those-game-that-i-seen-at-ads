using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    Damage,
    ShootCoolTime,
    COUNT
}

public class UpgradeItem : MonoBehaviour, ICollisionHandler
{
    public UIObjectCount uiCount;
    public ObjectPoolType poolType;
    public UpgradeType type;
    public int count;
    public float upgradeValue;

    private void OnEnable()
    {
        int minCount = 1 * (1 + CharacterManager.Instance.Player.playerSO.playerCloneNumber);
        int maxCount = 20 * (1 + CharacterManager.Instance.Player.playerSO.playerCloneNumber);
        count = Random.Range(minCount, maxCount);
        poolType = ObjectPoolType.UpgradeItemObject;
        type = (UpgradeType)Random.Range(0, (int)UpgradeType.COUNT);
        SetUpgradeValue();
        uiCount.UpdateCountUI(count);
    }

    public void SetUpgradeValue()
    {
        if (type == UpgradeType.Damage)
        {
            upgradeValue = Random.Range(0.5f, 5f);
        }
        else if (type == UpgradeType.ShootCoolTime)
        {
            upgradeValue = Random.Range(0.01f, 0.05f);
        }
    }

    public void OnBulletHit()
    {
        count--;

        uiCount.UpdateCountUI(count);

        if (count <= 0)
        {
            UpgradePlayer();

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

    private void UpgradePlayer()
    {
        if (type == UpgradeType.Damage)
        {
            CharacterManager.Instance.Player.playerSO.shootDamage += upgradeValue;
        }
        else if (type == UpgradeType.ShootCoolTime)
        {
            CharacterManager.Instance.Player.playerSO.shootCoolTime -= upgradeValue;
        }
    }
}