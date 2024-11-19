using System;
using UnityEngine;

[Serializable]
public class BossData
{
    [field: SerializeField] public float BossHp { get; private set; } // ���� ü�� 
    [field: SerializeField] public float BossMaxHp { get; private set; } // �ִ� ü��
    [field: SerializeField] public float BossSpeed { get; private set; } // �̵� �ӵ�
}

[CreateAssetMenu(fileName = "Boss", menuName = "Characters/Boss")]
public class BossSO : ScriptableObject
{
    [field: SerializeField] public BossData BossData { get; private set; }
}
