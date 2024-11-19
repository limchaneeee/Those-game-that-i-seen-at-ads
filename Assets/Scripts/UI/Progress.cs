using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI meterTxt;

    [SerializeField] private float curGauge;
    [SerializeField] private float minGauge = 0;
    [SerializeField] private float maxGauge = 100;

    private event Action onProgress;

    private void Awake()
    {
        //progressBar = GetComponentInChildren<Image>();
        meterTxt = GetComponentInChildren<TextMeshProUGUI>();
        curGauge = minGauge;
        onProgress += Getpercentage;
    }

    private void Getpercentage()
    {
        progressBar.fillAmount = curGauge / maxGauge;
    }

    private void ProgressRate()
    {
        if(curGauge < maxGauge)
        {
            curGauge += Time.deltaTime;
            meterTxt.text = curGauge.ToString("0" + "M");
            onProgress?.Invoke();
        }
        else
        {
            Debug.Log("스테이지 클리어");
        }
    }

    private void Update()
    {
        ProgressRate();
    }
}
