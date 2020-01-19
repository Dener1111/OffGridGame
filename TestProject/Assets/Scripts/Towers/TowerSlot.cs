using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    [SerializeField] Transform place;
    SpriteRenderer slotGraphic;
    BoxCollider coll;
    TowerController tower;

    [SerializeField] List<TowerController> towerTypes;

    void Start()
    {
        slotGraphic = GetComponentInChildren<SpriteRenderer>();
        coll = GetComponent<BoxCollider>();
    }

    void Update()
    {

    }

    public void PlaceTower(TowerController t)
    {
        tower = Instantiate(t, place.position, place.rotation, place);
        slotGraphic.enabled = false;
    }

    public void RemoveTower()
    {
        Destroy(tower.gameObject);
        slotGraphic.enabled = true;
    }

    void OnMouseDown()
    {
        if (tower)
            GUIController.inst.ShowTowerSellMenu(tower, this);
        else
            GUIController.inst.ShowTowerMenu(towerTypes, this);
        // Debug.Log(gameObject.name);
    }
}
