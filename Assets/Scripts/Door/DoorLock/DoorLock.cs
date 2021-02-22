using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private BattlefieldTrigger battlefieldTrigger;
    [SerializeField] private EnemySpawner enemySpawner;
    private Animator animator;
    private Collider2D collider2d;

    void Awake()
    {
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();

        collider2d.enabled = false;


        battlefieldTrigger.PlayerTriggered += LockDoor;
        enemySpawner.EnemiesKilledInBattleField += UnlockDoor;

    }

    private void LockDoor()
    {
        animator.SetTrigger("lockDoor");
        collider2d.enabled = true;
        //Debug.Log("lock");
    }

    private void UnlockDoor()
    {
        animator.SetTrigger("unlockDoor");
        collider2d.enabled = false;
        //Debug.Log("unlock");
    }

}
