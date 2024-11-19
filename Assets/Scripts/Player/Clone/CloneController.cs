using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float moveForce;
    [SerializeField] private float maxSpeed;
    WaitForSeconds wait = new WaitForSeconds(1.5f);
    private Vector3 directionToPlayer;

    private void Awake()
    {
        player = CharacterManager.Instance.Player.gameObject;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(GetDirectionToPlayer());
    }

    private void FixedUpdate()
    {        
        _rigidbody.AddForce(directionToPlayer * moveForce, ForceMode.Force);

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
    }
}
