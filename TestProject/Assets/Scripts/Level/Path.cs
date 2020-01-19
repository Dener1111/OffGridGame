using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] Sprite pathGraphic;
    public List<Transform> pathPoints;


    float pointDebugR = .5f;

    void OnDrawGizmos()
    {
        foreach (var item in pathPoints)
            Gizmos.DrawWireSphere(item.position, pointDebugR);
    }
}
