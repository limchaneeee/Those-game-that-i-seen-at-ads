using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 2f;

    private BulletPool bulletPool;

    public void SetPool(BulletPool pool)
    {
        bulletPool = pool;
    }

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
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void Deactivate()
    {
        bulletPool?.ReturnBullet(gameObject);
    }
}
