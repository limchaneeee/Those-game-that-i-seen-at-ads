using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public enum ObjectPoolType
{
    PlayerObject,
    EnemyObject,
    ItemObject,
    ObstacleObject,
    ProjectileObject,
    ParticleEffectObject
}

[Serializable]
public class PoolInfo
{
    public ObjectPoolType type;
    public int amount = 0;
    public GameObject prefab;
    public GameObject container;
    
    [HideInInspector]
    public Queue<GameObject> PoolQueue = new Queue<GameObject>();
}

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{
    // 오브젝트풀 리스트
    [SerializeField] private List<PoolInfo> listOfPool;
        
    private void Awake()
    {
        InitializeObjectPool();
    }

    // 풀 리스트에 따라서 오브젝트채워주기 (초기화)
    private void InitializeObjectPool()
    {
        foreach (PoolInfo poolInfo in listOfPool)
        {
            for (int i = 0; i < poolInfo.amount; i++)
            {
                poolInfo.PoolQueue.Enqueue(CreatNewObject(poolInfo));
            }
        }
    }

    // 오브젝트풀 안의 오브젝트 생성 메서드
    // 생성위치는 컨테이너 기준임
    private GameObject CreatNewObject(PoolInfo poolInfo)
    {
        GameObject obj = null;
        obj = Instantiate(poolInfo.prefab, poolInfo.container.transform);
        obj.gameObject.SetActive(false);

        return obj;
    }

    // 오브젝트풀에서 꺼내 쓸 때 사용하는 메서드
    public GameObject GetPoolObject(ObjectPoolType poolType)
    {
        PoolInfo selectedPool = GetPoolByType(poolType);

        GameObject obj = null;
        if (selectedPool.PoolQueue.Count > 0)
        {
            obj = selectedPool.PoolQueue.Dequeue();
        }
        else
        {
            obj = CreatNewObject(selectedPool);
        }
        obj.SetActive(true);
        return obj;
    }
    
    // 오브젝트풀에서 해당오브젝트 쓰고나서 비활성화 하는 메서드
    public void GetBackObject(GameObject obj, ObjectPoolType poolType)
    {
        PoolInfo selectedPool = GetPoolByType(poolType);
        selectedPool.PoolQueue.Enqueue(obj);
        obj.SetActive(false);
    }

    // enum형식의 ObjectPoolType을 해당하는 PoolInfo에 맞게 반환해주는 함수
    private PoolInfo GetPoolByType(ObjectPoolType poolType)
    {
        for (int i = 0; i < listOfPool.Count; i++)
        {
            if(poolType == listOfPool[i].type)
                return listOfPool[i];
        }

        return null;
    }
}