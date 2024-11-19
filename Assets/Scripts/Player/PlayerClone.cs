using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private List<GameObject> activeClones = new List<GameObject>();
    [SerializeField] private int currentCloneNumber;
    [SerializeField] private int maxCloneNumber;

    private void Start()
    {
        playerPosition = CharacterManager.Instance.Player.gameObject.transform;
        activeClones.Capacity = maxCloneNumber;
    }

    public void IncreasePlayerClone(int amount)
    {
        CharacterManager.Instance.Player.playerSO.playerCloneNumber += amount;
        currentCloneNumber = CharacterManager.Instance.Player.playerSO.playerCloneNumber;
        float spawnAngle = 360f / amount;
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

    public void DecreasePlayerClone(int amount)
    {
        if (activeClones.Count == 0)
        {
            return;
        }

        CharacterManager.Instance.Player.playerSO.playerCloneNumber -= amount;
        if (CharacterManager.Instance.Player.playerSO.playerCloneNumber < 0)
        {
            CharacterManager.Instance.Player.playerSO.playerCloneNumber = 0;
        }
        currentCloneNumber = CharacterManager.Instance.Player.playerSO.playerCloneNumber;

        if (currentCloneNumber == 0)
        {
            foreach (GameObject clone in activeClones)
            {
                ObjectPoolManager.Instance.GetBackObject(clone, ObjectPoolType.PlayerObject);
            }
            activeClones.Clear();
        }
        else if (currentCloneNumber > 0)
        {
            while (amount > 0)
            {
                ObjectPoolManager.Instance.GetBackObject(activeClones[activeClones.Count - 1], ObjectPoolType.PlayerObject);
                activeClones.RemoveAt(activeClones.Count - 1);
                amount--;
            }
        }
    }

    public void DeActivateClone()
    {
        CharacterManager.Instance.Player.playerSO.playerCloneNumber--;
        ObjectPoolManager.Instance.GetBackObject(activeClones[activeClones.Count - 1], ObjectPoolType.PlayerObject); ;
        activeClones.RemoveAt(activeClones.Count - 1);
    }
}