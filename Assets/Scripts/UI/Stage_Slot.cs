using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage_Slot : MonoBehaviour
{
    [SerializeField] private Button slotButton;

    private void Awake()
    {
        slotButton = GetComponent<Button>();
    }

    public void NextStage(int stageIndex)
    {
        Debug.Log($"현재 스테이지: {stageIndex}");
    }
}
