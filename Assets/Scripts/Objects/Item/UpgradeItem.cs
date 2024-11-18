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

    }

    public void OnPlayerCloneHit()
    {

    }

    private void UpgradePlayer()
    {
        if (type == UpgradeType.Damage)
        {
            CharacterManager.Instance.Player.playerSO.damage += upgradeValue;
        }
        else if (type == UpgradeType.ShootCoolTime)
        {
            CharacterManager.Instance.Player.playerSO.shootCoolTime -= upgradeValue;
        }
    }
}