
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudGolemProjectileLaunch : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackDelay;

    private float attackSpeedTemp;
    private bool canAttack;
    private bool isAttacking;
    private float attackRangeRadius;
    private Vector3 target;

    void Start()
    {
        attackSpeedTemp = attackSpeed;
        attackRangeRadius = transform.GetChild(0).GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        if(attackSpeedTemp > 0)
        {
            if(!canAttack && !isAttacking)
            {
                attackSpeedTemp -= Time.deltaTime;

            }
            
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
            target = enemies[ranNum].gameObject.transform.position;
            
            StartCoroutine("DelayAttack");
        }
    }

    private IEnumerator DelayAttack()
    {
        canAttack = false;
        isAttacking = true;
        GetComponent<MudGolem>().SetCanMove(false);
        
        yield return new WaitForSeconds(attackDelay);

        GameObject projectileObject = Instantiate(projectile, transform.position, transform.rotation);
        projectileObject.GetComponent<MudGolemProjectile>().SetTarget(target);
        projectileObject.GetComponent<MudGolemProjectile>().SetMoxGolemRange(attackRangeRadius);
        
        GetComponent<MudGolem>().SetCanMove(true);
        isAttacking = false;

    }

}
