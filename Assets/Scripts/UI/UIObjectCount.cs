using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UIObjectCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countTxt;
    [SerializeField] private int count;
    StringBuilder sb = new StringBuilder();

    public void UpdateCountUI(int _count)
    {
        count = _count;
        sb.Clear();
        sb.Append(count);

        UpdateUI();
    }

    public void UpdateUI()
    {
        countTxt.text = sb.ToString();
    }
}
