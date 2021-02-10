using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{


    // Called in Animator
    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
