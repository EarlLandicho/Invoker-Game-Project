#region

using UnityEngine;

#endregion

public class ProjectileAttack : EnemyAttack
{
	[SerializeField] protected Transform projectileLaunchPosition;
	[SerializeField] protected float projectileSpeed;
	protected Animator animator;
	protected GameObject currentProjectile;
	protected EnemyMovement enemyMovement;
	protected bool isAttacking;

	private new void Awake()
	{
		base.Awake();
		enemyMovement = GetComponent<EnemyMovement>();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (!isLockedAttack)
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
	}

	public override void SetLockAttack(bool isStunned)
	{
		base.SetLockAttack(isStunned);
		if (!isStunned)
		{
			ResetAttackSpeed();
			animator.SetBool("isStunned", false);
		}
		else
		{
			animator.SetBool("isStunned", true);
		}
	}

	// Called in Animator
	public void ResetAttackSpeed()
	{
		attackSpeedTemp = attackSpeed;
		isAttacking = false;
	}

	// Called in Animator
	public virtual void Attack()
	{
		currentProjectile = Instantiate(projectile, projectileLaunchPosition.position, transform.rotation);
		currentProjectile.GetComponent<EnemyProjectile>().SetDamage(damage);
		currentProjectile.GetComponent<EnemyProjectile>()
						 .SetPlayerDirection(ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject));
		currentProjectile.GetComponent<EnemyProjectile>().SetProjectileSpeed(projectileSpeed);
		currentProjectile.GetComponent<EnemyProjectile>().Launch();
	}
}