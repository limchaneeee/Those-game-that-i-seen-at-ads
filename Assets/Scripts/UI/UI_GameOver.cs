using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_GameOver : UIBase
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainButton;
    [SerializeField] private Button exitButton;

    protected override void Awake()
    {
        base.Awake();
        InitialResumeUI();
    }

    private void InitialResumeUI()
    {
        retryButton.onClick.AddListener(OnRetryBtnClicked);
        exitButton.onClick.AddListener(OnExitBtnClicked);
        mainButton.onClick.AddListener(OnMainBtnClicked);
        Time.timeScale = 0f;
    }

    private void OnRetryBtnClicked()
    {
        UIManager.Instance.HideAndTransitionScene("UI_GameOver", "InGame");
    }

    private void OnExitBtnClicked()
    {
        Application.Quit();
    }

    private void OnMainBtnClicked()
    {
        UIManager.Instance.HideAndTransitionScene("UI_GameOver","StartScene");
    }
}
