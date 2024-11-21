using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [field: SerializeField] public EnemySO Data { get; private set; }

    public NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        EnemyMovement();
    }
   
    private void EnemyMovement()
    {
        Vector3 movement = Data.EnemyData.EnemySpeed * Time.deltaTime * Vector3.back;
        agent.Move(movement);
    }
}
