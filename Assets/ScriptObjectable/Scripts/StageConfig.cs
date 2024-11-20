using UnityEngine;

[CreateAssetMenu(fileName = "StageConfig", menuName = "Configs/StageConfig")]
public class StageConfig : ScriptableObject
{
    public float ObjectSpawnRate;
    public float EnemySpawnRate;
    public BossSO BossData;
}
