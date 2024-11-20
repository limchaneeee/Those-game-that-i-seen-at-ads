using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Stage : UIBase
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform  buttonContainer;
    [SerializeField] private int totalStages = 10;

    private void Start()
    {
        for (int i = 1; i <= totalStages; i++)
        {
            var buttonObj = Instantiate(buttonPrefab, buttonContainer);
            var buttonScript = buttonObj.GetComponent<UI_StageButton>();
            
            buttonScript.SetUpButton(i);
        }
    }
}
