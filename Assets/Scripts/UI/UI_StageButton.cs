using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_StageButton : MonoBehaviour
{
    [SerializeField] private int stageIndex;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // TODO: 게임매니저에 스테이지 정보 전해주기 or 해당 스테이지 시작
        GameManager.Instance.SetSelectedStageIndex(stageIndex);
        UIManager.Instance.Hide("UI_Stage");
        SceneManager.LoadScene("InGame");
    }

    public void SetUpButton(int index)
    {
        stageIndex = index - 1;

        bool isUnlocked = GameManager.Instance.IsStageUnlocked(stageIndex);
        button.interactable = isUnlocked;
        
        GetComponentInChildren<TextMeshProUGUI>().text = $"{index}";
    }
}
