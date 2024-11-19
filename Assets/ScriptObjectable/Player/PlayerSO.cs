using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "Player", menuName = "Character/Player")]
public class PlayerSO : ScriptableObject
{
    public float playerMoveSpeed;
    public float shootCoolTime;
    public float shootDamage;
    public int playerCloneNumber;
}
