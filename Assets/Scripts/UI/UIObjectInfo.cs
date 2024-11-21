using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UIObjectInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoTxt;
    StringBuilder sb = new StringBuilder();

    public void UpdateInfo(UpgradeType _upgradeType)
    {
        if (_upgradeType == UpgradeType.Damage)
        {
            sb.Clear();
            sb.Append("Damage\nUp");
            infoTxt.text = sb.ToString();
        }
        else if (_upgradeType == UpgradeType.ShootCoolTime)
        {
            sb.Clear();
            sb.Append("RPM\nUP");
            infoTxt.text = sb.ToString();
        }
    }

    public void UpdateInfo(CloneVariationType _cloneVariationType, int _variationValue)
    {
        if (_cloneVariationType == CloneVariationType.SubstractAdd)
        {
            sb.Clear();
            
            if (_variationValue > 0)
            {
                sb.Append('+');
            }
            sb.Append(_variationValue);

            infoTxt.text = sb.ToString();
        }
        // else if (_cloneVariationType == CloneVariationType.DivideMultiply)
        // {
        //     sb.Clear();
        //     if (_variationValue < 0)
        //     {
        //         sb.Append('��');
        //     }
        //     else
        //     {
        //         sb.Append('��');
        //     }
        //     _variationValue = Mathf.Abs(_variationValue);
        //     sb.Append(_variationValue);
        //     infoTxt.text = sb.ToString();
        // }
    }
}
