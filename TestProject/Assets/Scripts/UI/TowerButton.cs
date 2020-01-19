using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    public Button btn;

    [Space]
    [SerializeField] TextMeshProUGUI towerName;
    [SerializeField] Image towerIcon;

    [SerializeField] TextMeshProUGUI towerDamage;
    [SerializeField] TextMeshProUGUI towerSpeed;
    [SerializeField] TextMeshProUGUI towerRange;
    [SerializeField] TextMeshProUGUI towerPrice;

    public TowerController tower;

    public TextMeshProUGUI TowerName { get => towerName; }
    public Image TowerIcon { get => towerIcon; }
    public TextMeshProUGUI TowerDamage { get => towerDamage; }
    public TextMeshProUGUI TowerSpeed { get => towerSpeed; }
    public TextMeshProUGUI TowerRange { get => towerRange; }
    public TextMeshProUGUI TowerPrice { get => towerPrice; }
}
