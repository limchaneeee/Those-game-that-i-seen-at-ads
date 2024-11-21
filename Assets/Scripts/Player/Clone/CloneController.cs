using UnityEngine;

public class CloneController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 tempPosition;

    private void OnEnable()
    {
        player = CharacterManager.Instance.Player.gameObject;
        moveSpeed = CharacterManager.Instance.Player.playerSO.playerMoveSpeed;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;

        _rigidbody.velocity = directionToPlayer * moveSpeed;

        if (transform.position.y > 0.01f)
        {
            tempPosition = transform.position;
            tempPosition.y = 0f;
            transform.position = tempPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ICollisionHandler collisionHandler = other.GetComponent<ICollisionHandler>();
        if (collisionHandler != null)
        {
            collisionHandler.OnPlayerCloneHit(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            CharacterManager.Instance.Player.cloneSpawner.DeActivateClone(gameObject);
        }
    }
}
