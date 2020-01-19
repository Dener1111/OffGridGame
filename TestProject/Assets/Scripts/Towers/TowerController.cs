using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public TowerBase towerBase;

    [SerializeField] Transform towerHead;
    [SerializeField] List<Transform> shootPoints;
    Transform currentShootPoint;
    int countShootPoint;

    Transform target;

    bool canShoot = true;

    void Start()
    {
        currentShootPoint = shootPoints[0];
    }

    void Update()
    {
        TowerLoop();
    }

    void TowerLoop()
    {
        if (target &&
            (Vector3.Distance(target.position, transform.position) > towerBase.range || !target.gameObject.activeSelf))
            target = null;

        if (target)
        {
            towerHead.LookAt(target.transform);

            if (canShoot)
                Shoot();
        }
        else
        {
            SetTarget();
        }
    }

    void SetTarget()
    {
        var enemies = Physics.OverlapSphere(transform.position, towerBase.range, EnemyManager.inst.EnemyLayer);
        if (enemies.Length > 0)
        {
            target = enemies.OrderBy
            (
                c => Vector3.Distance
                (
                    c.transform.position,
                    LevelController.inst.player.hitBox.position
                )
            ).ToArray()[0].transform;
        }
    }

    void Shoot()
    {
        StartCoroutine(_Help());

        IEnumerator _Help()
        {
            canShoot = false;

            ObjectPooler.inst.Spawn
            (
                towerBase.projectile,
                currentShootPoint.position,
                currentShootPoint.rotation
            ).GetComponent<Projectile>().damage = towerBase.damage;

            ChangeShootPoint();

            yield return new WaitForSeconds(1 / towerBase.speed);
            canShoot = true;
        }
    }

    void ChangeShootPoint()
    {
        if (shootPoints.Count <= 1)
            return;

        if (shootPoints.Count - 1 <= countShootPoint)
            countShootPoint = 0;

        currentShootPoint = shootPoints[countShootPoint++];
    }

    void OnDrawGizmos()
    {
        if (towerBase)
            Gizmos.DrawWireSphere(transform.position, towerBase.range);
    }
}
