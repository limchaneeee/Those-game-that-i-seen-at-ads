using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject shootPos;
    [SerializeField] private GameObject bulletParticlePrefab;
    [SerializeField] private float shootCoolTime;
    private float lastTime;
    public event Action<float> OnShoot;

    private void Start()
    {
        shootCoolTime = CharacterManager.Instance.Player.playerSO.shootCoolTime;
    }

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
        GameObject bullet = ObjectPoolManager.Instance.GetPoolObject(ObjectPoolType.ProjectileObject);
        bullet.transform.position = shootPos.transform.position;
        ObjectPoolManager.Instance.transform.rotation = Quaternion.identity;

        Instantiate(bulletParticlePrefab, shootPos.transform.position, Quaternion.identity);

        OnShoot?.Invoke(CharacterManager.Instance.Player.playerSO.shootDamage);
        SoundManager.Instance.PlaySFX(SoundFXType.GunShot);
    }

    public void UpgradeShootCoolTime()
    {
        shootCoolTime *= CharacterManager.Instance.Player.playerSO.upgradeShootCoolTimeValue;
    }
}
