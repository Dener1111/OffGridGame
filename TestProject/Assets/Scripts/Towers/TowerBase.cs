using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerBase", menuName = "ScriptableObjects/Tower", order = 1)]
public class TowerBase : ScriptableObject
{
    public string displayName;
    public Sprite icon;

    public int price;
    public int damage;
    public float range;
    [Tooltip("Projectiles per sec")] public float speed;

    public string projectile = "Projectile1";
}
