using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Transform camPos;
    

    private void Start()
    {
        camPos = Camera.main.transform;
    }

    private void GetPercentage()
    {
        //TODO: enemy ü�� ���� ��������
    }

    private void Update()
    {
        transform.LookAt(transform.position + camPos.rotation * Vector3.forward, camPos.rotation * Vector3.up);
    }
}
