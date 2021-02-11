using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class BattlefieldTrigger : MonoBehaviour
{
    public event Action PlayerTriggered = delegate { };
    

    private Collider2D collider2d;

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerTriggered();
            TurnOffCollider();
        }
    }

    private void TurnOffCollider()
    {
        collider2d.enabled = false;
    }
}
