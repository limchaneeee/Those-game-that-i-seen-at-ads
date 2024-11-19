using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject shootPos;
    private float lastTime;
    public event Action<float> OnShoot;

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
        OnShoot?.Invoke(CharacterManager.Instance.Player.playerSO.shootDamage);
        SoundManager.Instance.PlaySFX(SoundFXType.GunShot);
        
    }

}
