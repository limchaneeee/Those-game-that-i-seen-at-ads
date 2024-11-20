using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIUpgradeInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoTxt;

    public void UpdateInfo(UpgradeType _upgradeType)
    {
        if (_upgradeType == UpgradeType.Damage)
        {
            infoTxt.text = "Damage\nUp";
        }
        else if (_upgradeType == UpgradeType.ShootCoolTime)
        {
            infoTxt.text = "RPM\nUP";
        }
    }
}
