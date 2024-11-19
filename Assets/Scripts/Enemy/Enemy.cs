using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public EnemySO Data { get; private set; }

    private float health;

    private void Awake()
    {
        health = Data.EnemyData.EnemyHp;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;  

        if (health <= 0)
        {
            Die();  
        }
    }
    public void OnBulletHit()
    {
        TakeDamage(1);
    }

    private void Die()
    {
        Destroy(gameObject);  
    }
}
