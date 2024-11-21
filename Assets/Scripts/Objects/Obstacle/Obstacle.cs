using UnityEngine;

public class Obstacle : MonoBehaviour, ICollisionHandler
{
    public UIObjectCount uiCount;
    public ObjectPoolType poolType;
    public int count;

    private void OnEnable()
    {
        Initialize();
        uiCount.UpdateCountUI(count);
    }

    private void Initialize()
    {
        poolType = ObjectPoolType.ObstacleObject;
        int minCount = 5 * (1 + CharacterManager.Instance.Player.cloneSpawner.currentCloneNumber);
        int maxCount = 10 * (1 + CharacterManager.Instance.Player.cloneSpawner.currentCloneNumber);
        count = Random.Range(minCount, maxCount);
    }

    public void OnBulletHit()
    {
        count--;

        uiCount.UpdateCountUI(count);

        if (count <= 0)
        {
            ObjectPoolManager.Instance.GetBackObject(gameObject, poolType);
        }
    }

    public void OnPlayerHit()
    {
        CharacterManager.Instance.Player.cloneSpawner.DecreasePlayerClone(count);
    }

    public void OnPlayerCloneHit(GameObject obj)
    {
        CharacterManager.Instance.Player.cloneSpawner.DeActivateClone(obj);
    }

    public void OnBottomWallHit()
    {
        ObjectPoolManager.Instance.GetBackObject(gameObject, poolType);
    }

    public void OnChasingWallHit()
    {

    }
}
