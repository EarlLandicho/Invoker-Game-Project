using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private BattlefieldTrigger battlefieldTrigger;
    private Animator animator;
    private Collider2D collider2d;

    void Awake()
    {
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();

        collider2d.enabled = false;


        battlefieldTrigger.PlayerTriggered += LockDoor;
    }

    private void LockDoor()
    {
        animator.SetTrigger("isTriggered");
        collider2d.enabled = true;
    }

}
