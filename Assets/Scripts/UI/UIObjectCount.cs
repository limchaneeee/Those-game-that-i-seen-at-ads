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

    public void UpdateCountUI(int _count, CloneVariationType _cloneVariationType)
    {
        count = _count;
        if (_cloneVariationType == CloneVariationType.SubstractAdd)
        {
            sb.Clear();
            
            if (count >= 0)
            {
                sb.Append("+");
            }
            sb.Append(count);
        }
        // else if (_cloneVariationType == CloneVariationType.DivideMultiply)
        // {
        //     sb.Clear();
        //     if (count >= 0)
        //     {
        //         sb.Append('��');
        //     }
        //     else
        //     {
        //         sb.Append('��');
        //     }
        //     count = Mathf.Abs(count);
        //     sb.Append(count);
        // }
        //
        // UpdateUI();
    }

    public void UpdateUI()
    {
        countTxt.text = sb.ToString();
    }
}
