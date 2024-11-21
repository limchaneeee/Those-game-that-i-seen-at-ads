using UnityEngine;

public class ChasingWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollisionHandler collisionHandler = other.gameObject.GetComponent<ICollisionHandler>();
        if (collisionHandler != null)
        {
            collisionHandler.OnChasingWallHit();
        }
    }
}
