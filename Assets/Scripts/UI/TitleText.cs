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
        transform.localScale = Vector3.one * 0.1f;
        
        var seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1.2f, 0.5f));
        seq.Append(transform.DOScale(1f, 0.1f));
        seq.Play();
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.anyKeyDown)&& !isHidden)
        {
            isHidden = true;
            UIManager.Instance.Show<StagePanel>();
            Hide();
        }
    }
}
