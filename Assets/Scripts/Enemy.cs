using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public EnemySO enemyData { get; private set; }

    private NavMeshAgent agent;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        EnemyMovement();
    }
    void Update()
    {

    }

    private void EnemyMovement()
    {
        throw new NotImplementedException();
    }

}
