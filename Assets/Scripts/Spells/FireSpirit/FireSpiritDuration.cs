using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpiritDuration : MonoBehaviour
{
    [SerializeField] private float duration;

    private float durationTemp;

    void Awake()
    {
        durationTemp = duration;
    }


    void Update()
    {
        if (durationTemp > 0)
        {
            durationTemp -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
