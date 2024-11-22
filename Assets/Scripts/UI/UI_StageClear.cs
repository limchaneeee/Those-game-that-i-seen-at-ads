using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_StageClear : UIBase
{
    [SerializeField] private Button nextStageButton;
    [SerializeField] private Button mainButton;
    [SerializeField] private Button exitButton;

    protected override void Awake()
    {
        base.Awake();
        InitialStageClearUI();
    }

    private void InitialStageClearUI()
    {
        nextStageButton.onClick.AddListener(OnNextStageBtnClicked);
        exitButton.onClick.AddListener(OnExitBtnClicked);
        mainButton.onClick.AddListener(OnMainBtnClicked);
        Time.timeScale = 0f;
    }

    private void OnNextStageBtnClicked()
    {
        GameManager.Instance.SelectedStageIndex = SpawnManager.Instance.currentStageIndex;
        SceneManager.LoadScene("InGame");
        Time.timeScale = 1f;
        Hide();
    }

    private void OnExitBtnClicked()
    {
        Application.Quit();
    }

    private void OnMainBtnClicked()
    {
        UIManager.Instance.HideAndTransitionScene("UI_StageClear","StartScene");
    }
}
