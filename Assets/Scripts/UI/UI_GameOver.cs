
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
        // TODO: 현재 스테이지 정보 그대로 게임 다시 시작하도록 하기 + UI닫기
    }

    private void OnExitBtnClicked()
    {
        // TODO: UI닫기
        Application.Quit();
    }

    private void OnMainBtnClicked()
    {
        SceneManager.LoadScene("StartScene");
    }
}
