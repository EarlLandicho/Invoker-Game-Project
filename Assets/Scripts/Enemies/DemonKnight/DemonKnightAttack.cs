using UnityEngine;
using System.Collections;

public class DemonKnightAttack : EnemyAttack
{
    [SerializeField] private float attackDelay;
    private GameObject currentProjectile;
    private bool isBeingDelayed;
    private DemonKnightMovement demonKnightMovement;

    new void Awake()
    {
        base.Awake();
        demonKnightMovement = GetComponent<DemonKnightMovement>();

    }

    void Update()
    {
        if (attackSpeedTemp > 0 && !isLockedAttack)
        {
            attackSpeedTemp -= Time.deltaTime;
        }
        else if (!isBeingDelayed && attackSpeedTemp <= 0)
        {
            StartCoroutine("DelayAttack");

        }

    }

    public override void SetLockAttack(bool isStunned)
    {
        this.isLockedAttack = isStunned;
        if (isStunned)
        {
            StopAllCoroutines();
            attackSpeedTemp = attackSpeed;
        }
        else
        {
            StartCoroutine("DelayAttack");
        }
    }

    private IEnumerator DelayAttack()
    {
        isBeingDelayed = true;
        demonKnightMovement.SetLockXMovement(true);

        yield return new WaitForSeconds(attackDelay);
        currentProjectile = Instantiate(projectile, transform.position, transform.rotation);
        currentProjectile.GetComponent<EnemyProjectile>().SetDamage(damage);
        currentProjectile.GetComponent<EnemyProjectile>().SetPlayerDirection(ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject));
        currentProjectile.GetComponent<EnemyProjectile>().Launch();
        attackSpeedTemp = attackSpeed;
        isBeingDelayed = false;
        demonKnightMovement.SetLockXMovement(false);
        
    }
}