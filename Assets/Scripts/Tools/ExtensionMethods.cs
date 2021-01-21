using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }

    public static Vector2 GetNormalizedDirectionToPlayer2D(GameObject currentObject)
    {
        GameObject playerObject = GameObject.Find("Player");
        return (playerObject.transform.position - currentObject.transform.position).normalized;
    }
}
