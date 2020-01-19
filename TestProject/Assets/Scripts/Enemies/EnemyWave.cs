using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveBase", menuName = "ScriptableObjects/EnemyWave")]
public class EnemyWave : ScriptableObject
{
    [Tooltip("duration til next wave in seconds")] public int duration;
    // [Tooltip("1 = 1 enemy/sec")] public float spawnRate = 1;
    public float TimeBetweenSpawn;

    public List<EnemyNameCount> enemies;
}

[System.Serializable]
public class EnemyNameCount
{
    public string tag;
    public int count;
}
