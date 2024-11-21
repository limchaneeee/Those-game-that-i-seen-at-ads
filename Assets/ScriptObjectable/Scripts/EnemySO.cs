using System;
using UnityEngine;

[Serializable]
public class EnemyData
{
    [field: SerializeField] public float EnemyHp { get; private set; }
    [field: SerializeField] public float EnemyMaxHp { get; private set; }
    [field: SerializeField] public float EnemySpeed { get; private set; }
    [field: SerializeField] public float EnemyChasingRange { get; private set; }
}

[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public EnemyData EnemyData { get; private set; }
}
