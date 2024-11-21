using UnityEngine;

public class BottomWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollisionHandler collisionHandler = other.gameObject.GetComponent<ICollisionHandler>();
        if (collisionHandler != null)
        {
            collisionHandler.OnBottomWallHit();
        }
    }
}
