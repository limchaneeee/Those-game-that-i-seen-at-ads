using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    [field: SerializeField] public float EnemyHp { get; private set; }
    [field: SerializeField] public float EnemyMaxHp { get; private set; }
    [field: SerializeField] public float EnemySpeed { get; private set; }
}

[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public EnemyData enemyData { get; private set; }
}
