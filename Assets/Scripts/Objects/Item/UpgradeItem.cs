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
    [SerializeField] UpgradeType type;
    [SerializeField] private float count;

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