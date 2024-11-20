using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitleText : UIBase
{
    private bool isHidden = false;
    private void Start()
    {
        PopUpAnimaition();
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.anyKeyDown)&& !isHidden)
        {
            isHidden = true;
            UIManager.Instance.Show<UI_Stage>();
            CloseAnimation();
            Hide();
        }
    }
}
