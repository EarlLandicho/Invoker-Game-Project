using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudGolemProjectileLaunch : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float attackSpeed;

    private float attackSpeedTemp;
    private bool canAttack;
    private float attackRangeRadius;

    void Start()
    {
        attackSpeedTemp = attackSpeed;
        attackRangeRadius = transform.GetChild(0).GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        if(attackSpeedTemp > 0 && !canAttack)
        {
            attackSpeedTemp -= Time.deltaTime;
            
        }
        else
        {
            canAttack = true;
            attackSpeedTemp = attackSpeed;
        }



    }





    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy") && canAttack)
        {
            AttackRandomEnemyInRange();
        }
    }

    private void AttackRandomEnemyInRange()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRangeRadius, 1 << LayerMask.NameToLayer("Enemy"));

        if (enemies.Length > 0)
        {
            int ranNum = Random.Range(0, enemies.Length);
            GameObject projectileObject = Instantiate(projectile, transform.position, transform.rotation);
            projectileObject.GetComponent<MudGolemProjectile>().SetTarget(enemies[ranNum].gameObject.transform.position);
            projectileObject.GetComponent<MudGolemProjectile>().SetMoxGolemRange(attackRangeRadius);
            canAttack = false;
        }
    }



}
