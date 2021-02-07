using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, IEnemyAttack
{
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected float damage;
    [SerializeField] protected float attackSpeed;

    protected float attackSpeedTemp;
    protected GameObject playerObject;
    protected bool isStunned;

    public virtual void SetLockAttack(bool isStunned)
    {
        this.isStunned = isStunned;
    }

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
