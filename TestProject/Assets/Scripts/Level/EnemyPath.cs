using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] Sprite pathGraphic;
    public List<Transform> pathPoints;

    string pathGraphicName = "PathLine";

    public void GeneratePath()
    {
        if (pathPoints != null)
        {
            int i = 0;
            foreach (var item in pathPoints)
            {
                var go = new GameObject(pathGraphicName);
                go.transform.parent = item;
                go.transform.localPosition = Vector3.zero;
                go.transform.eulerAngles = Vector3.right * 90;

                var sr = go.AddComponent<SpriteRenderer>();
                sr.sprite = pathGraphic;

                if (i < pathPoints.Count - 1)
                {
                    pathPoints[i].LookAt(pathPoints[i + 1]);
                    go.transform.localScale = new Vector3(1, Vector3.Distance(pathPoints[i].position, pathPoints[++i].position), 1);
                }
            }
        }
    }

    public Transform this[int i]
    {
        get => pathPoints[i];
    }

    // float pointDebugR = .5f;

    // void OnDrawGizmos()
    // {
    //     foreach (var item in pathPoints)
    //         Gizmos.DrawWireSphere(item.position, pointDebugR);
    // }
}
