using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private List<GameObject> activeClones = new List<GameObject>();
    [SerializeField] private int currentCloneNumber;
    [SerializeField] private int maxCloneNumber;

    private void Awake()
    {
        playerPosition = CharacterManager.Instance.Player.gameObject.transform;
    }

    public void IncreasePlayerClone(int amount)
    {
        currentCloneNumber = CharacterManager.Instance.Player.playerSO.playerCloneNumber;
        float spawnAngle = 360f / currentCloneNumber;
        float distance = 1f;

        for (int i = 0; i < amount; i++)
        {
            GameObject clone = ObjectPoolManager.Instance.GetPoolObject(ObjectPoolType.PlayerObject);
            if (clone != null)
            {
                float angle = i * spawnAngle;
                Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * distance, 0, Mathf.Sin(angle * Mathf.Deg2Rad) * distance);
                clone.transform.position = playerPosition.position + offset;
                activeClones.Add(clone);
            }
        }
    }
}
