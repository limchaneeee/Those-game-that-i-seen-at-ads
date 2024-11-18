using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [SerializeField] private LayerMask dieLayer; //파괴가능한 오브젝트, 적군, 보스
    private void OnCollisionEnter(Collision collision)
    {
        if(((1 << collision.gameObject.layer) & dieLayer) != 0)
        {
            Destroy(gameObject); //나중에는 파괴말고, 플레이어 풀에 넣었다 뺏다로 변경예정
        }

    }
}
