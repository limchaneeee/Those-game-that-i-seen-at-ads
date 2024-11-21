using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ICollisionHandler
{
    [field: SerializeField] public EnemySO Data { get; private set; }
    [SerializeField] private HPBar hpBar;

    public NavMeshAgent agent;
    public Transform player;

    public float health;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Data.EnemyData.EnemySpeed;
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

    public void OnBulletHit( )
    {
        float playerAttackDamage = CharacterManager.Instance.Player.playerSO.shootDamage;
        TakeDamage(playerAttackDamage);
      
    }
    public void OnPlayerHit() { }

    public void OnPlayerCloneHit(GameObject obj) { }

    public void OnBottomWallHit() 
    {
        Die();
    }

    public void OnChasingWallHit() 
    {
        player = GameObject.FindWithTag("Player").transform;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        agent.SetDestination(player.position);
    }
}
