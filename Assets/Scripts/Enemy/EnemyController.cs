using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [field: SerializeField] public EnemySO Data { get; private set; }

    public NavMeshAgent agent;
    public Transform player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= Data.EnemyData.EnemyChasingRange)
        {
            agent.SetDestination(player.position);
        }
    }
}
