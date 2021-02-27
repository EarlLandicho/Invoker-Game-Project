using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BattlefieldTrigger : MonoBehaviour
{
    public event Action PlayerTriggered = delegate { };

    private Collider2D collider2d;

    private void Awake()
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