using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TouchToEndGame : MonoBehaviour
{
    public static event Action EndGameByTouch = delegate { };

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            EndGameByTouch();
        }
    }



}
