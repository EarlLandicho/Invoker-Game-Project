using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeMushroomAttack : EnemyAttack
{
	private Animator animator;
	private bool isAttacking;
	protected GameObject currentProjectile;



	private new void Awake()
	{
		base.Awake();
		animator = GetComponent<Animator>();
	}
	
	protected void Update()
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
	
	public virtual void Attack()
	{
		currentProjectile = Instantiate(projectile, transform.position, transform.rotation);
		currentProjectile.GetComponent<EnemyProjectile>().SetDamage(damage);
	}

}
