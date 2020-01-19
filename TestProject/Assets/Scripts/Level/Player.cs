using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Transform hitBox;

    [SerializeField] int maxHP;
    int hp;

    private int coins;

    public int Hp
    {
        get => hp;
        private set
        {
            hp = value;
            hpEvent.Invoke();
        }
    }

    [SerializeField] int startCoins;
    public int Coins
    {
        get => coins;
        private set
        {
            coins = value;
            coinEvent.Invoke();
        }
    }

    [HideInInspector] public UnityEvent hpEvent;
    [HideInInspector] public UnityEvent coinEvent;

    void Awake()
    {
        hpEvent = new UnityEvent();
        coinEvent = new UnityEvent();
    }

    void Start()
    {
        Hp = maxHP;
        Coins = startCoins;
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
            Die();
    }

    public void Die()
    {
        LevelController.inst.EndGame(false);
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
    }

    public void RemoveCoin(int amount)
    {
        Coins -= amount;
    }
}
