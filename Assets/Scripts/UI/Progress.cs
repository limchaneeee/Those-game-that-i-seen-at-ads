using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI meterTxt;

    [SerializeField] private float curGauge;
    [SerializeField] private float minGauge = 0;
    [SerializeField] private float maxGauge = 100;

    private event Action onProgress;
    private event Action onGaugeFull;

    private void Awake()
    {
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
            onGaugeFull?.Invoke();
            onGaugeFull = null;
        }
    }

    private void Update()
    {
        ProgressRate();
    }
    public void SetOnGaugeFullListener(Action listener)
    {
        onGaugeFull += listener;
    }
}
