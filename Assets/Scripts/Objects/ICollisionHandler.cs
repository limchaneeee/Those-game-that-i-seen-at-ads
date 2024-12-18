using UnityEngine;

public interface ICollisionHandler
{
    public void OnBulletHit();
    public void OnPlayerHit();
    public void OnPlayerCloneHit(GameObject obj);
    public void OnBottomWallHit();
    public void OnChasingWallHit();
}
