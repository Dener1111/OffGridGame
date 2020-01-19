using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager inst;

    public LayerMask EnemyLayer;

    EnemyWave currentWave;
    [HideInInspector] public int currentWaveCount;

    Coroutine mainCoroutine;

    void Awake()
    {
        if (!inst)
            inst = this;
    }

    void Start()
    {
        currentWaveCount = 0;
    }

    public void StartWave()
    {
        currentWave = LevelController.inst.waves[currentWaveCount++];
        if (mainCoroutine != null)//not sure if its necessary
            StopCoroutine(mainCoroutine);
        mainCoroutine = StartCoroutine(_StartWave());
    }

    IEnumerator _StartWave()
    {
        List<int> enemyCounter = new List<int>();
        foreach (var item in currentWave.enemies)
            enemyCounter.Add(item.count);

        int enemyType = 0;

        float elapsed = 0;
        while (elapsed < currentWave.duration)
        {
            yield return new WaitForSeconds(currentWave.TimeBetweenSpawn);
            elapsed += currentWave.TimeBetweenSpawn;

            if (enemyCounter[enemyType] > 0)
            {
                SpawnEnemy(currentWave.enemies[enemyType].tag, LevelController.inst.path[0]);
                enemyCounter[enemyType]--;

                if (enemyCounter[enemyType] <= 0 && enemyType < currentWave.enemies.Count - 1)
                    enemyType++;
            }
            else
                yield break;
        }
    }

    void SpawnEnemy(string tag, Transform pos)
    {
        ObjectPooler.inst.Spawn
        (
            tag,
            pos.position,
            pos.rotation
        );
    }
}
