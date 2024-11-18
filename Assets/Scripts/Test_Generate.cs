using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Generate : MonoBehaviour
{
    
    public void Click()
    {
        int random = Random.Range(0, 4);

        StartCoroutine(GenerateRoutine(RandomSelect(random)));
    }

    private ObjectPoolType RandomSelect(int random)
    {
        if(random == 0)
            return ObjectPoolType.PlayerObject;
        else if (random == 1)
            return ObjectPoolType.EnemyObject;
        else if (random == 2)
            return ObjectPoolType.ItemObject;
        else
            return ObjectPoolType.ObstacleObject;
    }

    private IEnumerator GenerateRoutine(ObjectPoolType type)
    {
        GameObject obj = ObjectPoolManager.Instance.GetPoolObject(type);

        obj.transform.position = new Vector3(0, 0, 0);
        obj.gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);
        
        ObjectPoolManager.Instance.GetBackObject(obj, type);
    }
}
