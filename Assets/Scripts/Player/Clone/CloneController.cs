using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float moveForce;
    [SerializeField] private float maxSpeed;
    WaitForSeconds wait = new WaitForSeconds(1f);
    private Vector3 directionToPlayer;
    private Vector3 tempPosition;

    private void Awake()
    {
        player = CharacterManager.Instance.Player.gameObject;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(GetDirectionToPlayer());
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(directionToPlayer * moveForce, ForceMode.Force);

        if (transform.position.y > 0.01f)
        {
            tempPosition = transform.position;
            tempPosition.y = 0f;
            transform.position = tempPosition;
        }

        if (_rigidbody.velocity.magnitude > maxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
        }
    }

    IEnumerator GetDirectionToPlayer()
    {
        while (true)
        {
            directionToPlayer = (player.transform.position - transform.position).normalized;
            directionToPlayer.y = 0;
            yield return wait;
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
