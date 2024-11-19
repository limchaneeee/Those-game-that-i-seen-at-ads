using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //[SerializeField] private ObjectPoolManager bulletPool;
    [SerializeField] private GameObject shootPos;
    //[SerializeField] private float shootCoolTime; //SO���� ����������
    private float lastTime;


    private void Update()
    {
        if(Time.time - lastTime >= CharacterManager.Instance.Player.playerSO.shootCoolTime)
        {
            lastTime = Time.time;
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        GameObject bullet = ObjectPoolManager.Instance.GetPoolObject(ObjectPoolType.ProjectileObject);
        bullet.transform.position = shootPos.transform.position;
        ObjectPoolManager.Instance.transform.rotation = Quaternion.identity;
        SoundManager.Instance.PlaySFX(SoundFXType.GunShot);
    }

}
