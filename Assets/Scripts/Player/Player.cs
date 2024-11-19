using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerSO playerSO;
    public PlayerShooting shooting;
    public CloneSpawner cloneSpawner;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        shooting = GetComponent<PlayerShooting>();
        cloneSpawner = GetComponent<CloneSpawner>();
    }
}
