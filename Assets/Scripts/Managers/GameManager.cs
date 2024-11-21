using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoSingleton<GameManager>
{
    [HideInInspector]
    public bool _isGamePlaying = true;

    private int totalStages = 10;
    public bool[] unlockedStages;
    
    public int SelectedStageIndex { get;  set; }
    
    public override void Awake()
    {
        base.Awake();
        InitStageData();
    }

    public void PauseGame()
    {
        if (_isGamePlaying && UIManager.Instance.uiList.Count == 0)
        {
            Time.timeScale = 0;
            _isGamePlaying = false;
            UIManager.Instance.Show<UI_Resume>();
        }
        else if(!_isGamePlaying && UIManager.Instance.uiList.Count == 1)
        {
            Time.timeScale = 1;
            _isGamePlaying = true;
            UIManager.Instance.Hide("UI_Resume");
            
        }
    }

    private void InitStageData()
    {
        unlockedStages = new bool[totalStages];
        unlockedStages[0] = true;
    }

    public bool IsStageUnlocked(int stageIndex)
    {
        return stageIndex >= 0 && stageIndex < unlockedStages.Length && unlockedStages[stageIndex];
    }

    public void UnlcokNextStage(int stageIndex)
    {
        if (stageIndex >= 0 && stageIndex < unlockedStages.Length)
        {
            unlockedStages[stageIndex] = true;
        }
    }

    public void SetSelectedStageIndex(int stageIndex)
    {
        SelectedStageIndex = stageIndex;
    }
    
}
