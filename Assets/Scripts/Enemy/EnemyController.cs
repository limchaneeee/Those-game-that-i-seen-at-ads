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

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        EnemyChasing();
    }

    private void EnemyMovement()
    {
        Vector3 movement =   Data.EnemyData.EnemySpeed * Time.deltaTime * Vector3.back;
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