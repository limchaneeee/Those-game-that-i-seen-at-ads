using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Resume : UIBase
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainButton;
    [SerializeField] private Button exitButton;

    protected override void Awake()
    {
        base.Awake();
        InitialResumeUI();
    }

    private void InitialResumeUI()
    {
        resumeButton.onClick.AddListener(OnResumeBtnClicked);
        exitButton.onClick.AddListener(OnExitBtnClicked);
        mainButton.onClick.AddListener(OnMainBtnClicked);
    }

    private void OnResumeBtnClicked()
    {
        GameManager.Instance.PauseGame();
    }

    private void OnExitBtnClicked()
    {
        Application.Quit();
    }

    private void OnMainBtnClicked()
    {
        
        GameManager.Instance._isGamePlaying = true;
        UIManager.Instance.HideAndTransitionScene("UI_Resume","StartScene");
    }
}
