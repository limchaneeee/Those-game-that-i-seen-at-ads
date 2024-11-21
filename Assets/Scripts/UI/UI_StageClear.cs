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
        InitialResumeUI();
    }

    private void InitialResumeUI()
    {
        nextStageButton.onClick.AddListener(OnNextStageBtnClicked);
        exitButton.onClick.AddListener(OnExitBtnClicked);
        mainButton.onClick.AddListener(OnMainBtnClicked);
        Time.timeScale = 0f;
    }

    private void OnNextStageBtnClicked()
    {
        // TODO: 다음 스테이지 정보를 가지고 다시 시작하도록 하기 + UI닫기
        int currentSTageIndex = SpawnManager.Instance.currentStageIndex;
        SpawnManager.Instance.StartStage(currentSTageIndex);
        Time.timeScale = 1f;
        Hide();
    }

    private void OnExitBtnClicked()
    {
        Application.Quit();
    }

    private void OnMainBtnClicked()
    {
        SceneManager.LoadScene("StartScene");
        Hide();
    }
}
