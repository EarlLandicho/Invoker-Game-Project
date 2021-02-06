using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleProjectileAttack : EnemyAttack
{
    [SerializeField] private Transform projectileLaunchPosition;
    [SerializeField] private float projectileSpeed;


    private GameObject currentProjectile;

    private EnemyMovement enemyMovement;
    private Animator animator;
    private bool isAttacking;

    new void Awake()
    {
        base.Awake();
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (attackSpeedTemp > 0)
        {
            attackSpeedTemp -= Time.deltaTime;
        }
        else if (attackSpeedTemp <= 0 && !isAttacking)
        {
            animator.SetTrigger("attack");
            isAttacking = true;
        }

    }


    // Called in Animator
    public void ResetAttackSpeed()
    {
        attackSpeedTemp = attackSpeed;
        isAttacking = false;
    }

    // Called in Animator
    public void Attack()
    {
        currentProjectile = Instantiate(projectile, projectileLaunchPosition.position, transform.rotation);
        currentProjectile.GetComponent<EnemyProjectile>().SetDamage(damage);
        currentProjectile.GetComponent<EnemyProjectile>().SetPlayerDirection(ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject));
        currentProjectile.GetComponent<EnemyProjectile>().SetProjectileSpeed(projectileSpeed);
        currentProjectile.GetComponent<EnemyProjectile>().Launch();
    }

}
