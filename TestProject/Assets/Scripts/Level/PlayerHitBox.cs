using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = LevelController.inst.player;
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyController enemy;
        if (other.transform.TryGetComponent<EnemyController>(out enemy))
        {
            player.TakeDamage(enemy.enemyBase.damage);
        }

    }
}
