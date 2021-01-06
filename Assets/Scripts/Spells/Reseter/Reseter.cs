using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour
{
    private SpiritCast spiritCast;
    void Awake()
    {
        spiritCast = (SpiritCast)GameObject.FindObjectOfType(typeof(SpiritCast));

        spiritCast.ResetAllCooldowns();
    }



}
