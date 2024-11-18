using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CloneNumChangeType
{
    SubstractAdd,
    DivideMultiply
}

public class CloneNumChangeItem : MonoBehaviour, ICollisionable
{
    [SerializeField] private CloneNumChangeType type;
    [SerializeField] private float count;

    public void OnBulletHit()
    {
        count++;
    }
}
