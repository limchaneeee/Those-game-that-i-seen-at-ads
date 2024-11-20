using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ICollisionHandler
{
    [field: SerializeField] public EnemySO Data { get; private set; }
    [SerializeField] private HPBar hpBar;

    public float health;


    private void Awake()
    {
        health = Data.EnemyData.EnemyHp;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        hpBar.UpdateHPBar();

        if (health <= 0)
        {
            Die();  
        }
    }
    private void Die()
    {
        Destroy(gameObject);  
    }

    public void OnBulletHit()
    {
        float playerAttackDamage = CharacterManager.Instance.Player.playerSO.shootDamage;
        TakeDamage(playerAttackDamage);
    }
    public void OnPlayerHit() { }

    public void OnPlayerCloneHit(GameObject obj) { }

    public void OnBottomWallHit() { }
}
