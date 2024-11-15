using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;
    public event Action OnAttack;

    [Header("Move")]
    private Vector2 moveInput;
    [SerializeField] private float moveSpeed = 10f;



    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * moveInput.x;
        dir *= moveSpeed;
        rigid.velocity = dir;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            moveInput = Vector2.zero;
        }
    }

    public void Attack()
    {
        OnAttack?.Invoke();
    }
}
