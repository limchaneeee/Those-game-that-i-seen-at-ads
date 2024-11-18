using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    //[SerializeField] private GameObject bulletPrefab;
    //[SerializeField] private int poolSize = 30;

    //private Queue<Bullet> pool = new Queue<Bullet>();

    //private void Awake()
    //{
    //    for (int i = 0; i < poolSize; i++)
    //    {
    //        GameObject bulletObj = Instantiate(bulletPrefab);
    //        Bullet bullet = bulletObj.GetComponent<Bullet>();
    //        bullet.SetPool(this);
    //        bulletObj.SetActive(false);
    //        pool.Enqueue(bullet);
    //    }
    //}

    //public GameObject GetBullet()
    //{
    //    Bullet bullet;

    //    if (pool.Count > 0)
    //    {
    //        bullet = pool.Dequeue();
    //    }
    //    else
    //    {
    //        GameObject bulletObj = Instantiate(bulletPrefab);
    //        bullet = bulletObj.GetComponent<Bullet>();
    //        bullet.SetPool(this);
    //    }

    //    bullet.gameObject.SetActive(true);
    //    return bullet.gameObject;
    //}

    //public void ReturnBullet(GameObject bulletObj)
    //{
    //    Bullet bullet = bulletObj.GetComponent<Bullet>();
    //    bulletObj.SetActive(false);
    //    pool.Enqueue(bullet);
    //}
}
