using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovement))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected float damage;
    [SerializeField] protected float attackSpeed;

    protected float attackSpeedTemp;
    protected GameObject playerObject;

    protected void Awake()
    {
        playerObject = GameObject.Find("Player");
        attackSpeedTemp = attackSpeed;
    }

    protected Vector2 GetNormalizedDirectionToPlayer2D()
    {
        return (playerObject.transform.position - transform.position).normalized;
    }

 

}
