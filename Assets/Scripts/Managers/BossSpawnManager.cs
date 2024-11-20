using System.Collections;
using UnityEngine;

public class BossSpawnManager : MonoBehaviour
{
    [Header("Boss Settings")]
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private Vector3 targetPosition;

    private GameObject currentBoss;
    private Boss bossScript;
    private float moveSpeed;

    [Header("BossSO Reference")]
    [SerializeField] private BossSO bossSO;

    [Header("Progress Reference")]
    [SerializeField] private Progress progressScript;

    [Header("Spawner References")]
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private EnemySpawn enemySpawn;

    private bool isBossSpawned = false;

    private void Start()
    {
        if (progressScript == null)
        {
            progressScript = FindObjectOfType<Progress>(); // Progress 객체
        }

        if (progressScript == null)
        {
            return;
        }

        moveSpeed = bossSO.BossData.BossSpeed;

        progressScript.SetOnGaugeFullListener(SpawnAndMoveBoss);
    }

    private void SpawnAndMoveBoss()
    {
        if (!isBossSpawned)
        {
            isBossSpawned = true;

            if (objectSpawner != null)
                objectSpawner.enabled = false; // 스크립트 비활성화

            if (enemySpawn != null)
                enemySpawn.enabled = false; // 스크립트 비활성화

            StartCoroutine(SpawnAndMoveBossCoroutine());
        }
    }

    private IEnumerator SpawnAndMoveBossCoroutine()
    {
        currentBoss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
        bossScript = currentBoss.GetComponent<Boss>();

        bossScript.OnBossDeath += HandleBossDeath;

        while (currentBoss != null && Vector3.Distance(currentBoss.transform.position, targetPosition) > 0.1f)
        {
            if (currentBoss == null)
            {
                yield break;
            }

            currentBoss.transform.position = Vector3.MoveTowards(currentBoss.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        if (currentBoss != null)
        {
            StartBossAttack();
        }
    }

    private void StartBossAttack()
    {
        if (bossScript != null)
        {
            Animator bossAnimator = currentBoss.GetComponent<Animator>();

            if (bossAnimator != null)
            {
                bossAnimator.SetBool("Idle", true);
            }

            bossScript.StartCoroutine(bossScript.AttackPatternRoutine());
        }
    }

    // 보스 죽음 처리
    private void HandleBossDeath()
    {
        if (objectSpawner != null)
            objectSpawner.enabled = true; // 스크립트 활성화

        if (enemySpawn != null)
            enemySpawn.enabled = true; // 스크립트 활성화

        isBossSpawned = false;
    }
}
