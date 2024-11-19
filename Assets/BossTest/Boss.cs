using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Boss Stats")]
    [SerializeField] private BossSO bossData;  // SO 데이터
    private float currentHp;
    private bool isDead = false;

    [Header("Attack Pattern Settings")]
    [SerializeField] private GameObject attackPrefab1;  // 패턴 1 프리팹
    [SerializeField] private GameObject attackPrefab2;  // 패턴 2 프리팹
    [SerializeField] private GameObject attackPrefab3;  // 패턴 3 프리팹

    [SerializeField] private Vector3[] spawnPositionsForPattern1;  // 패턴 1 위치 
    [SerializeField] private Vector3[] spawnPositionsForPattern3;  // 패턴 3 위치

    [Header("Attack Interval")]
    [SerializeField] private float attackInterval = 5f;  // 공격 딜레이

    private void Start()
    {
        currentHp = bossData.BossData.BossHp;
        StartCoroutine(AttackPatternRoutine());
    }

    public IEnumerator AttackPatternRoutine()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(attackInterval);

            int patternIndex = Random.Range(0, 3);

            switch (patternIndex)
            {
                case 0:
                    ExecuteAttackPattern1(); 
                    break;
                case 1:
                    ExecuteAttackPattern2();  
                    break;
                case 2:
                    ExecuteAttackPattern3();  
                    break;
            }
        }
    }

    private void ExecuteAttackPattern1()
    {
        // 패턴 1: 프리팹 하나 소환 (장애물 소환?)
        Vector3 spawnPosition = spawnPositionsForPattern1[Random.Range(0, spawnPositionsForPattern1.Length)];
        Instantiate(attackPrefab1, spawnPosition, Quaternion.identity);
    }

    private void ExecuteAttackPattern2()
    {
        // 패턴 2: 프리팹 발사 (Bullet 발사?)
        Vector3 forwardDirection = transform.forward;
        Vector3 spawnPosition = transform.position + forwardDirection * -2f;

        spawnPosition.y = transform.position.y - 2f;

        Instantiate(attackPrefab2, spawnPosition, Quaternion.identity);

        // 만약 bullet 받아온다면 > 좌표 수정 할 것, 현재도 y값 수정 필요
    }

    private void ExecuteAttackPattern3()
    {
        // 패턴 3: 프리팹 여러개 소환 (적들 소환?)
        foreach (Vector3 position in spawnPositionsForPattern3)
        {
            Instantiate(attackPrefab3, position, Quaternion.identity);
        }
    }

    // 피해 받을 때,
    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHp -= damage;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    // 죽었을 때,
    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
