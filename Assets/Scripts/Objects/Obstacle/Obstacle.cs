using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ICollisionable
{
    [SerializeField] private float count;

    public void OnBulletHit()
    {
        count--;

        if (count <= 0)
        {
            // ObjectPool - Release
            Destroy(gameObject);
        }
    }
}
