using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private GameObject bulletParticlePrefab;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss") || other.CompareTag("Obstacle")) 
        {
            GameObject particle = ObjectPoolManager.Instance.GetPoolObject(ObjectPoolType.ParticleEffectObject);
            particle.transform.position = transform.position;
            particle.transform.rotation = Quaternion.identity;

            ICollisionHandler collisionHandler = other.gameObject.GetComponent<ICollisionHandler>();

            if (collisionHandler != null)
            {
                collisionHandler.OnBulletHit();
               
            }
            Deactivate();
        }

       
    }
}
