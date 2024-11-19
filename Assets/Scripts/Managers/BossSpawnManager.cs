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

    private void Start()
    {
        moveSpeed = bossSO.BossData.BossSpeed;

        StartCoroutine(SpawnAndMoveBoss());
    }

    private IEnumerator SpawnAndMoveBoss()
    {
        currentBoss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
        bossScript = currentBoss.GetComponent<Boss>();

        while (Vector3.Distance(currentBoss.transform.position, targetPosition) > 0.1f)
        {
            currentBoss.transform.position = Vector3.MoveTowards(currentBoss.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;  
        }

        StartBossAttack();
    }

    private void StartBossAttack()
    {
        if (bossScript != null)
        {
            bossScript.StartCoroutine(bossScript.AttackPatternRoutine());
        }
    }
}
