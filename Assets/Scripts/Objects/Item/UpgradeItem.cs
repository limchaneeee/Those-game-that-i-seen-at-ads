using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    Damage,
    ShootCoolTime
}

public class UpgradeItem : MonoBehaviour, ICollisionHandler
{
    [SerializeField] private UpgradeType type;
    [SerializeField] private float upgradeValue;
    [SerializeField] private int count;

    public void OnBulletHit()
    {
        count--;

        if (count <= 0)
        {
            UpgradePlayer();

            //ObjectPool - Release
            Destroy(gameObject);
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