using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Boss : MonoBehaviour, ICollisionHandler
{
    [Header("Boss Stats")]
    [SerializeField] private BossSO bossData;  // SO 데이터
    private float currentHp;
    private bool isDead = false;

    [Header("Attack Pattern Settings")]
    [SerializeField] private GameObject attackPrefab1;  // 패턴 1 프리팹
    [SerializeField] private GameObject attackPrefab2;  // 패턴 2 프리팹

    [SerializeField] private Vector3[] spawnPositionsForPattern1;  // 패턴 1 위치
    [SerializeField] private Vector3[] spawnPositionsForPattern2;  // 패턴 2 위치

    [Header("Attack Interval")]
    [SerializeField] private float attackInterval = 3f;  // 공격 딜레이

    [Header("UI Elements")]
    [SerializeField] private Image healthBarFill;
    [SerializeField] private Text healthText;

    // 보스 사망 이벤트
    public event Action OnBossDeath;

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

            int patternIndex = UnityEngine.Random.Range(0, 2);

            switch (patternIndex)
            {
                case 0:
                    ExecuteAttackPattern1();
                    break;
                case 1:
                    ExecuteAttackPattern2();
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
        // 패턴 2: Enemy 소환
        foreach (Vector3 position in spawnPositionsForPattern2)
        {
            Quaternion rotation = Quaternion.Euler(0f, 180f, 0f);

            Instantiate(attackPrefab2, position, rotation);
        }
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

    // 보스 죽음
    private void Die()
    {
        isDead = true;

        Animator bossAnimator = GetComponent<Animator>();

        if (bossAnimator != null)
        {
            bossAnimator.SetTrigger("Death");
        }

        SpawnManager.Instance.isBossDead = true;
        // 사망 이벤트 호출
        OnBossDeath?.Invoke();

        Destroy(gameObject, 1f);
        UIManager.Instance.Show<UI_StageClear>();
    }

    public void OnBulletHit()
    {
        TakeDamage(CharacterManager.Instance.Player.playerSO.shootDamage);
    }

    // ICollisionHandler 용

    public void OnPlayerHit() { }

    public void OnPlayerCloneHit(GameObject obj) { }

    public void OnBottomWallHit() { }

    public void OnChasingWallHit() { }
}
