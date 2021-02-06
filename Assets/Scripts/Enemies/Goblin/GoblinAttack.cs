using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GoblinAttack : EnemyAttack
{
    [SerializeField] private float attackDelay;
    private GameObject currentProjectile;
    private GoblinMovement goblinMovement;
    private bool isBeingDelayed;

    new void Awake()
    {
        base.Awake();
        goblinMovement = GetComponent<GoblinMovement>();

    }

    void Update()
    {
        if (attackSpeedTemp > 0 && !isStunned)
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
        this.isStunned = isStunned;
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
        goblinMovement.SetLockXMovement(true);

        yield return new WaitForSeconds(attackDelay);
        currentProjectile = Instantiate(projectile, transform.position, transform.rotation);
        currentProjectile.GetComponent<EnemyProjectile>().SetDamage(damage);
        currentProjectile.GetComponent<EnemyProjectile>().SetPlayerDirection(ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject));
        currentProjectile.GetComponent<EnemyProjectile>().Launch();
        attackSpeedTemp = attackSpeed;
        isBeingDelayed = false;
        goblinMovement.SetLockXMovement(false);

    }


}