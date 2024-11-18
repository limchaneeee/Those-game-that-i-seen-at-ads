using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;

    [Header("Move")]
    private Vector2 moveInput;
    //[SerializeField] private float moveSpeed = 10f; //SO에서 가져와 쓰도록

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
        Vector3 dir = transform.right * moveInput.x;
        dir *= CharacterManager.Instance.Player.playerSO.playerMoveSpeed;
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
}
