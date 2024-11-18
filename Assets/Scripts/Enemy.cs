using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public EnemySO Data { get; private set; }

    public NavMeshAgent agent;
    public Transform player;

    private float health;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        health = Data.EnemyData.EnemyHp;
    }

    void Start()
    {
        agent.speed = Data.EnemyData.EnemySpeed;
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        EnemyMovement();
        EnemyChasing();
    }

    private void EnemyMovement()
    {
        Vector3 movement = Vector3.back * Data.EnemyData.EnemySpeed * Time.deltaTime;
        agent.Move(movement);
    }

    private void EnemyChasing() 
    {
        //�÷��̾�� �Ÿ����
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= Data.EnemyData.EnemyChasingRange)
        {
            agent.SetDestination(player.position);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;  

        if (health <= 0)
        {
            Die();  
        }
    }

    private void Die()
    {
        Destroy(gameObject);  
    }

}