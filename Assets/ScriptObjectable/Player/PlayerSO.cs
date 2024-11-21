using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "Player", menuName = "Character/Player")]
public class PlayerSO : ScriptableObject
{
    public float playerMoveSpeed;
    public float shootCoolTime;
    public float shootDamage;
    //public int playerCloneNumber;

    public float upgradeShootCoolTimeValue;

    public void ChangeUpgradeShootCoolTimeValue(float amount)
    {
        upgradeShootCoolTimeValue = Mathf.Clamp(upgradeShootCoolTimeValue - amount, 0.3f, 1f);
    }

    public float UpgradeShootCoolTime()
    {
        float changed = shootCoolTime * upgradeShootCoolTimeValue;
        return changed;
    }
}
