using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;  
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

    [Header("Player Stats")]
    [SerializeField] private PlayerSO playerData;

    [Header("UI Elements")]
    [SerializeField] private Image healthBarFill; 
    [SerializeField] private Text healthText;     

    public event Action<float> OnDamageTaken;

    private void Start()
    {
        currentHp = bossData.BossData.BossHp;
        StartCoroutine(AttackPatternRoutine());
        UpdateHealthBar();  
        UpdateHealthText(); 
    }

    public IEnumerator AttackPatternRoutine()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(attackInterval);

            int patternIndex = UnityEngine.Random.Range(0, 3); // 명시적

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
        // 패턴 1: 장애물 소환
        Vector3 spawnPosition = spawnPositionsForPattern1[UnityEngine.Random.Range(0, spawnPositionsForPattern1.Length)];
        Instantiate(attackPrefab1, spawnPosition, Quaternion.identity);
    }

    private void ExecuteAttackPattern2()
    {
        // 패턴 2: 프리팹 발사 (Bullet 발사?)
        Vector3 forwardDirection = transform.forward;
        Vector3 spawnPosition = transform.position + forwardDirection * 2f;

        spawnPosition.y = transform.position.y - 2f;

        Instantiate(attackPrefab2, spawnPosition, Quaternion.identity);
    }

    private void ExecuteAttackPattern3()
    {
        // 패턴 3: Enemy 소환
        foreach (Vector3 position in spawnPositionsForPattern3)
        {
            Instantiate(attackPrefab3, position, Quaternion.identity);
        }
    }

    public void OnBulletHit()
    {
        OnDamageTaken?.Invoke(playerData.shootDamage);
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHp -= damage;
        if (currentHp <= 0)
        {
            Die();
        }

        UpdateHealthBar();  
        UpdateHealthText(); 
    }

    private void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            float healthPercentage = currentHp / bossData.BossData.BossHp;
            healthBarFill.fillAmount = Mathf.Clamp01(healthPercentage);  
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = $"{currentHp}";
        }
    }

    // 죽었을 때
    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
