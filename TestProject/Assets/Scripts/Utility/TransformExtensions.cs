using System.Collections;
using System.Collections.Generic;
// using MEC;
using UnityEngine;

public static class TransformExtensions
{
    /// <summary>
    /// Destroys all children of transform
    /// </summary>
    public static void Clear(this Transform t)
    {
        foreach (Transform item in t)
        {
            GameObject.Destroy(item.gameObject);
        }
    }

    // private static void Animate(this Transform t, AnimationCurve animationCurve, Vector3 direction, float time = 0)
    // {
    //     // Timing.KillCoroutines($"_AnimateHelp{t.gameObject.GetInstanceID()}");
    //     Timing.RunCoroutine(_AnimateHelp(), $"_AnimateHelp{t.gameObject.GetInstanceID()}");
    //     IEnumerator<float> _AnimateHelp()
    //     {
    //         // Vector3 startPos = t.position;
    //         float elapsed = 0;
    //         float elapsedNormal;
    //         while(elapsed < time)
    //         {
    //             elapsedNormal = Mathf.InverseLerp(0, time, elapsed);
    //             t.position = direction * animationCurve.Evaluate(elapsedNormal);

    //             elapsed += Time.deltaTime;
    //             yield return Timing.WaitForOneFrame;
    //         }
    //         t.position = direction * animationCurve.Evaluate(1);
    //         // t.position = startPos + (direction * animationCurve.Evaluate(1));
    //     }
    // }
}

public static class Vector3Extensions
{
    // /// <summary>
    // /// rounds X and Z values
    // /// </summary>
    // public static Vector3 Round(this Vector3 vector3)
    // {
    //     return vector3.Round(Vector3.up);
    // }

    // /// <summary>
    // /// direction value of 0 rounds X, Y and Z values
    // /// </summary>
    // public static Vector3 Round(this Vector3 vector3, Vector3 dir)
    // {
    //     return new Vector3
    //     (
    //         dir.x == 0 ? Mathf.Round(vector3.x) : vector3.x,
    //         dir.y == 0 ? Mathf.Round(vector3.y) : vector3.y,
    //         dir.z == 0 ? Mathf.Round(vector3.z) : vector3.z
    //     );
    // }

    public static Vector3 Divide(this Vector3 a, Vector3 b)
    {
        return new Vector3
        (
            (float)System.Math.Round(a.x / b.x, 5),
            (float)System.Math.Round(a.y / b.y, 5),
            (float)System.Math.Round(a.z / b.z, 5)
        );
    }

    /// <summary>
    /// rounds X and Z values
    /// with specification of digits after point
    /// </summary>
    public static Vector3 Round(this Vector3 vector3, int digits = 0)
    {
        return vector3.Round(Vector3.up, digits);
    }

    /// <summary>
    /// direction value of 0 rounds X, Y and Z values
    /// with specification of digits after point
    /// </summary>
    public static Vector3 Round(this Vector3 vector3, Vector3 dir, int digits = 0)
    {
        return new Vector3
        (
            dir.x == 0 ? (float)System.Math.Round(vector3.x, digits) : vector3.x,
            dir.y == 0 ? (float)System.Math.Round(vector3.y, digits) : vector3.y,
            dir.z == 0 ? (float)System.Math.Round(vector3.z, digits) : vector3.z
        );
    }
}
