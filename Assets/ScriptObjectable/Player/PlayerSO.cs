using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "Player", menuName = "Character/Player")]
public class PlayerSO : ScriptableObject
{
    public float playerMoveSpeed;
    public float damage;
    public float shootCoolTime;
    public int playerCloneNumber;
    public GameObject playerClonePrefab;
}