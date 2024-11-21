using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    public BossSpawnManager bossSpawnManager;
    public ObjectSpawner objectSpawner;
    public EnemySpawn enemySpawn;

    [Header("Stage configurations")]
    public StageConfig[] stageConfigs;

    [HideInInspector]
    public int currentStageIndex = 0;
    private bool isStageActive = false;
    
    [HideInInspector]
    public bool isBossDead = false;
    
    public override void Awake()
    {
        base.Awake();
        Initialize();
    }

    private void Initialize()
    {
        bossSpawnManager = GetComponent<BossSpawnManager>();
        objectSpawner = GetComponent<ObjectSpawner>();
        enemySpawn = GetComponent<EnemySpawn>();
        int stageIndex = GameManager.Instance.SelectedStageIndex;
        StartStage(stageIndex);
    }

    public void StartStage(int stageIndex)
    {
        if (GameManager.Instance.IsStageUnlocked(stageIndex))
        {
            currentStageIndex = stageIndex;
            isStageActive = true;
            Time.timeScale = 1f;
            ApllyStageConfig(stageConfigs[stageIndex]);
        }
    }

    private void ApllyStageConfig(StageConfig stageConfig)
    {
        objectSpawner.SetSpawnRate(stageConfig.ObjectSpawnRate);
        enemySpawn.SetSpawnRate(stageConfig.EnemySpawnRate);
        bossSpawnManager.ConfigureBoss(stageConfig.BossData);
    }

    public void EndStage()
    {
        isStageActive = false;
        currentStageIndex++;
        GameManager.Instance.UnlcokNextStage(currentStageIndex);
        UIManager.Instance.Show<UI_StageClear>();
    }

    public void SetSpawninActive(bool isActive)
    {
        objectSpawner.enabled = isActive;
        enemySpawn.enabled = isActive;
    }

    private void Update()
    {
        if (isStageActive && isBossDead)
        {
            EndStage();
        }
    }


}
