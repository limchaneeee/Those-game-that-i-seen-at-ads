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

    public void InitPlayerStat()
    {
        playerMoveSpeed = 5f;
        shootCoolTime = 0.4f;
        shootDamage = 5f;
        upgradeShootCoolTimeValue = 1f;
    }
}
