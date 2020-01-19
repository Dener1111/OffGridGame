using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IPoolable
{
    public EnemyBase enemyBase;
    [SerializeField] Transform graphics;

    int hp;

    EnemyPath path;
    int pathPoint;

    float randPosRange = .2f;

    float minDist = .2f;

    void Start()
    {
        hp = enemyBase.hp;
    }

    void FixedUpdate()
    {
        MainLoop();
    }

    void MainLoop()
    {
        if (pathPoint >= path.pathPoints.Count - 1)
        {
            gameObject.SetActive(false);
            return;
        }

        if (Vector3.Distance(transform.position, path[pathPoint + 1].position) > minDist)//Mathf.Epsilon
        {
            var h = path[pathPoint + 1].position - transform.position;
            var dir = h / h.magnitude;
            transform.Translate(dir * enemyBase.speed * Time.deltaTime);
        }
        else
        {
            pathPoint++;
        }
    }

    public void Activate()
    {
        path = LevelController.inst.path;
        transform.localPosition += Vector3.right * Random.Range(-randPosRange, randPosRange);
        graphics.localEulerAngles = Vector3.up * Random.Range(0, 360);
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;

        //damage effect

        if (hp <= 0)
            Die();
    }

    void Die()
    {
        LevelController.inst.player.AddCoins((int)Random.Range(enemyBase.reward.x, enemyBase.reward.y + 1));
        gameObject.SetActive(false);
    }
}
