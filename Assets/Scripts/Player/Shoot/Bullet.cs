using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private GameObject bulletParticlePrefab;

    //private ObjectPoolManager bulletPool;

    private void OnEnable()
    {
        Invoke(nameof(Deactivate), lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    private void Shoot()
    {
        transform.position += speed * Time.deltaTime * transform.forward ;
    }

    private void Deactivate()
    {
        ObjectPoolManager.Instance.GetBackObject(gameObject,ObjectPoolType.ProjectileObject);
    }

    //Test
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(bulletParticlePrefab, transform.position, Quaternion.identity);
        ICollisionHandler collisionHandler = other.gameObject.GetComponent<ICollisionHandler>();

        if (collisionHandler != null)
        {
            collisionHandler.OnBulletHit();
            Deactivate();
        }
    }
}
