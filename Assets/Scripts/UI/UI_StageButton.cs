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
        GameManager.Instance.SetSelectedStageIndex(stageIndex);
        UIManager.Instance.HideAndTransitionScene("UI_Stage","InGame");
    }

    public void SetUpButton(int index)
    {
        stageIndex = index - 1;

        bool isUnlocked = GameManager.Instance.IsStageUnlocked(stageIndex);
        button.interactable = isUnlocked;
        
        GetComponentInChildren<TextMeshProUGUI>().text = $"{index}";
    }
}
