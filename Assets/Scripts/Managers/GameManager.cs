using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoSingleton<GameManager>
{
    // inherited MonoSingleton. Don't static.
    // **if you're going to use Awake method, it would be to use 'override'** By Chamsol.

    private bool _isGamePlaying = true;

    private int totalStages = 10;
    public bool[] unlockedStages;
    
    public int SelectedStageIndex { get; private set; }
    
    public override void Awake()
    {
        base.Awake();
        InitStageData();
    }

    public void PauseGame()
    {
        if (_isGamePlaying)
        {
            Time.timeScale = 0;
            _isGamePlaying = false;
            // todo: Pop up the pauseUI that used UIManager.
            UIManager.Instance.Show<UI_Resume>();
        }
        else
        {
            Time.timeScale = 1;
            _isGamePlaying = true;
            // todo: Close the pauseUI in UIResume.cs
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
