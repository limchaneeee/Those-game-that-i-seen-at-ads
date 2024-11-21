using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [SerializeField] private LayerMask dieLayer;
    

    private void OnTriggerEnter(Collider other)
    {
        ICollisionHandler collisionHandler = other.gameObject.GetComponent<ICollisionHandler>();
        if (collisionHandler != null)
        {
            collisionHandler.OnPlayerHit();
        }

         if(((1 << other.gameObject.layer) & dieLayer) != 0)
        {
            CharacterManager.Instance.Player.playerSO.InitPlayerStat();
            Destroy(gameObject);
            UIManager.Instance.Show<UI_GameOver>();
        }
    }
}
