using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [SerializeField] private LayerMask dieLayer; //�ı������� ������Ʈ, ����, ����
    private void OnCollisionEnter(Collision collision)
    {
        if(((1 << collision.gameObject.layer) & dieLayer) != 0)
        {
            Destroy(gameObject); //���߿��� �ı�����, �÷��̾� Ǯ�� �־��� ���ٷ� ���濹��
        }

    }
}