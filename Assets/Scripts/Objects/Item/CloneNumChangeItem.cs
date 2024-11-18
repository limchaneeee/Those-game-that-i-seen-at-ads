using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CloneNumChangeType
{
    SubstractAdd,
    DivideMultiply
}

public class CloneNumChangeItem : MonoBehaviour, ICollisionHandler
{
    [SerializeField] private CloneNumChangeType type;
    [SerializeField] private int count;

    public void OnBulletHit()
    {
        count++;
    }

    public void OnPlayerHit()
    {
        if (type == CloneNumChangeType.SubstractAdd)
        {
            if (count > 0)
            {
                CharacterManager.Instance.Player.playerClone.IncreasePlayerClone(count);
            }
            else if (count < 0)
            {
                //CharacterManager.Instance.Player.playerClone.DecreasePlayerClone(count);
            }
        }
        else if (type == CloneNumChangeType.DivideMultiply)
        {
            if (count < 0)
            {
                int amount = CharacterManager.Instance.Player.playerSO.playerCloneNumber * (1 - (1 / (count * -1)));
                //CharacterManager.Instance.Player.playerClone.DecreasePlayerClone(amount);
            }
            else if (count > 0)
            {
                int amount = CharacterManager.Instance.Player.playerSO.playerCloneNumber * (count - 1);
                CharacterManager.Instance.Player.playerClone.IncreasePlayerClone(amount);
            }
        }

        //ObjectPool 사용 예정
        Destroy(gameObject);
    }

    public void OnPlayerCloneHit()
    {
        return;
    }
}
