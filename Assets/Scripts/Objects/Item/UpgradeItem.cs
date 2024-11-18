using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    Damage,
    ShootCoolTime
}

public class UpgradeItem : MonoBehaviour, ICollisionable
{
    [SerializeField] private UpgradeType type;
    [SerializeField] private float upgradeValue;
    [SerializeField] private int count;

    public void OnBulletHit()
    {
        count--;

        if (count <= 0)
        {
            //UpgradePlayer();

            //ObjectPool - Release
            Destroy(gameObject);
        }
    }
}