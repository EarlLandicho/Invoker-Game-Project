using System;
using UnityEngine;

public class TouchToEndGame : MonoBehaviour
{
    public static event Action EndGameByTouch = delegate { };

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            EndGameByTouch();
        }
    }
}