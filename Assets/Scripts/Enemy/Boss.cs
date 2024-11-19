using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour 
{
    [Header("Boss Stats")]
    [SerializeField] private BossSO bossData;  // SO ������
    private float currentHp;
    private bool isDead = false;

    [Header("Attack Pattern Settings")]
    [SerializeField] private GameObject attackPrefab1;  // ���� 1 ������
    [SerializeField] private GameObject attackPrefab2;  // ���� 2 ������
    [SerializeField] private GameObject attackPrefab3;  // ���� 3 ������

    [SerializeField] private Vector3[] spawnPositionsForPattern1;  // ���� 1 ��ġ 
    [SerializeField] private Vector3[] spawnPositionsForPattern3;  // ���� 3 ��ġ

    [Header("Attack Interval")]
    [SerializeField] private float attackInterval = 5f;  // ���� ������

    [Header("Player Stats")]
    [SerializeField] private PlayerSO playerData;

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
        // ���� 1: ������ �ϳ� ��ȯ (��ֹ� ��ȯ?)
        Vector3 spawnPosition = spawnPositionsForPattern1[Random.Range(0, spawnPositionsForPattern1.Length)];
        Instantiate(attackPrefab1, spawnPosition, Quaternion.identity);
    }

    private void ExecuteAttackPattern2()
    {
        // ���� 2: ������ �߻� (Bullet �߻�?)
        Vector3 forwardDirection = transform.forward;
        Vector3 spawnPosition = transform.position + forwardDirection * 2f;

        spawnPosition.y = transform.position.y - 2f;

        Instantiate(attackPrefab2, spawnPosition, Quaternion.identity);
    }

    private void ExecuteAttackPattern3()
    {
        // ���� 3: ������ ���� �� ��ȯ (���� ��ȯ?)
        foreach (Vector3 position in spawnPositionsForPattern3)
        {
            Instantiate(attackPrefab3, position, Quaternion.identity);
        }
    }
    public void OnBulletHit()
    {
        TakeDamage(playerData.shootDamage); // player �� shootDamage ��ŭ ����
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHp -= damage;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    // �׾��� ��
    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
