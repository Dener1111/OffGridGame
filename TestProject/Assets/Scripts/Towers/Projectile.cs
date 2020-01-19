using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IPoolable
{

    [HideInInspector] public int damage;
    [SerializeField] float speed;

    [SerializeField] float lifeTime = 8f;
    float elapsedLifeTime;

    float skinWidth = .1f;

    Coroutine disCoroutine;

    public void Activate()
    {
        DisableSelf();
    }

    void Update()
    {
        float moveDistance = speed * Time.timeScale * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance + skinWidth, EnemyManager.inst.EnemyLayer, QueryTriggerInteraction.Collide))
            OnHitObject(hit.collider, hit.point);
    }

    void OnHitObject(Collider c, Vector3 hitPoint)
    {
        EnemyController enemy;
        if (c.TryGetComponent<EnemyController>(out enemy))
        {
            enemy.TakeDamage(damage);
        }

        DisableSelf(true);
    }

    void DisableSelf(bool immediately = false)
    {
        if (disCoroutine != null)
            StopCoroutine(disCoroutine);

        disCoroutine = StartCoroutine(_DisableSelf(immediately));
    }

    IEnumerator _DisableSelf(bool immediately)
    {
        if (!immediately)
            yield return new WaitForSeconds(lifeTime);

        gameObject.SetActive(false);
    }
}
