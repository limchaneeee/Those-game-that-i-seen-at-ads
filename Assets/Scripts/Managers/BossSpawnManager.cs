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
    
    private bool isBossSpawned = false;

    private void Start()
    {
        if (progressScript == null)
        {
            progressScript = FindObjectOfType<Progress>(); // Progress ��ü
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

            SpawnManager.Instance.SetSpawninActive(false);
            
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



    public void ConfigureBoss(BossSO newBossSO)
    {
        bossSO = newBossSO;
    }

    // ���� ���� ó��
    private void HandleBossDeath()
    {
        SpawnManager.Instance.SetSpawninActive(true);
        
        isBossSpawned = false;
    }
}
