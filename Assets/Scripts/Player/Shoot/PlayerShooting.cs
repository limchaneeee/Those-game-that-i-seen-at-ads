using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private GameObject shootPos;
    [SerializeField] private float shootCoolTime = 1f;
    private float lastTime;


    private void Update()
    {
        if(Time.time - lastTime >= shootCoolTime)
        {
            lastTime = Time.time;
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = shootPos.transform.position;
        bulletPool.transform.rotation = Quaternion.identity;
    }

}
