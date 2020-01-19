using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBase", menuName = "ScriptableObjects/Enemy", order = 2)]

public class EnemyBase : ScriptableObject
{
    public string displayName;

    public int hp;
    public float speed;
    public int damage;
    public Vector2 reward;
}
