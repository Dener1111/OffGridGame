using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    public static GUIController inst;

    [Header("Stats")]
    [SerializeField] TextMeshProUGUI waves;
    [SerializeField] TextMeshProUGUI waveTimer;

    [SerializeField] TextMeshProUGUI playerHp;
    [SerializeField] TextMeshProUGUI playerCoin;

    [Header("Tower Stuff")]
    [SerializeField] GameObject towerMenu;
    [SerializeField] Transform towerList;
    [SerializeField] TowerButton towerButton;

    [Header("Screens")]
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;

    void Awake()
    {
        if (!inst)
            inst = this;

        LevelController.inst.player.hpEvent.AddListener(() => playerHp.text = LevelController.inst.player.Hp.ToString());
        LevelController.inst.player.coinEvent.AddListener(() => playerCoin.text = LevelController.inst.player.Coins.ToString());
    }

    void Start()
    {
        LevelController.inst.timerEvent.AddListener(UpdateTimer);
    }

    void UpdateTimer()
    {
        waveTimer.text = LevelController.inst.Timer.ToString();
    }

    public void ShowTowerMenu(List<TowerController> towers, TowerSlot tSlot)
    {
        towerMenu.SetActive(true);

        foreach (var item in towers)
        {
            var tmp = CreateTowerButton(item);

            // tmp.tower
            tmp.btn.onClick.AddListener(() =>
            {
                if (item.towerBase.price <= LevelController.inst.player.Coins)
                {
                    LevelController.inst.player.RemoveCoin(item.towerBase.price);
                    tSlot.PlaceTower(item);
                    CloseTowerMenu();
                }
            });
            // tmp.btn.onClick.AddListener(() => Debug.Log("place"));
        }
    }

    public void ShowTowerSellMenu(TowerController tower, TowerSlot tSlot)
    {
        towerMenu.SetActive(true);

        var tmp = CreateTowerButton(tower);

        tmp.btn.onClick.AddListener(() =>
        {
            LevelController.inst.player.AddCoins(tower.towerBase.price);
            tSlot.RemoveTower();
            CloseTowerMenu();
        });
    }

    TowerButton CreateTowerButton(TowerController item)
    {
        var tmp = Instantiate(towerButton, towerList.position, Quaternion.identity, towerList);

        tmp.TowerName.text = item.towerBase.displayName;
        tmp.TowerIcon.sprite = item.towerBase.icon;
        tmp.TowerDamage.text = item.towerBase.damage.ToString();
        tmp.TowerSpeed.text = item.towerBase.speed.ToString();
        tmp.TowerRange.text = item.towerBase.range.ToString();
        tmp.TowerPrice.text = item.towerBase.price.ToString();

        return tmp;
    }

    public void CloseTowerMenu()
    {
        towerList.Clear();
        towerMenu.SetActive(false);
    }

    public void ChangeWave(int current, int total)
    {
        waves.text = $"{current}/{total}";
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
