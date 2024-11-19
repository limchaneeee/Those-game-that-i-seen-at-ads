using System;
using UnityEngine;

[Serializable]
public class BossData
{
    [field: SerializeField] public float BossHp { get; private set; } // 현재 체력 
    [field: SerializeField] public float BossMaxHp { get; private set; } // 최대 체력
    [field: SerializeField] public float BossSpeed { get; private set; } // 이동 속도
}

[CreateAssetMenu(fileName = "Boss", menuName = "Characters/Boss")]
public class BossSO : ScriptableObject
{
    [field: SerializeField] public BossData BossData { get; private set; }
}
