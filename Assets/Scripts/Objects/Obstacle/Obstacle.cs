using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ICollisionHandler
{
    [SerializeField] private int count;

    public void OnBulletHit()
    {
        count--;

        if (count <= 0)
        {
            // ObjectPool - Release
            Destroy(gameObject);
        }
    }

    public void OnPlayerHit()
    {

    }

    public void OnPlayerCloneHit()
    {

    }
}
