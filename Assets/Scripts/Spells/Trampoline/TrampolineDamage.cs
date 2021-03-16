#region

using System;
using UnityEngine;

#endregion

public class TrampolineDamage : MonoBehaviour
{
	[SerializeField] private float damage;
	[SerializeField] private float comboBarAddedDamage;
	[SerializeField] private Vector2 size = new Vector2(0, 0);
	[SerializeField] private GameObject projectile;
	private Animator animator;
	private TrampolineJump trampolineJump;
	
	private ComboBar comboBar;
	private float damageTemp;

	private void Awake()
	{
		trampolineJump = GetComponent<TrampolineJump>();
		animator = GetComponent<Animator>();
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
		trampolineJump.TrampolineJumped += DamageEnemy;
	}

	private void Start()
	{
		damageTemp = damage;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireCube((Vector2) transform.position, size);
	}

	private void DamageEnemy()
	{
		animator.SetTrigger("attack");
		Collider2D[] enemies = Physics2D.OverlapBoxAll(transform.position, size, 0, 1 << LayerMask.NameToLayer("Enemy"));
		foreach (Collider2D enemy in enemies)
		{
			ComboBarCheck();
			enemy.gameObject.GetComponent<IHealth>().TakeDamage(damageTemp);

			if (comboBar.GetComboBarStage() == 4)
			{
				enemy.gameObject.GetComponent<StatusEffect>().BecomeStunned();
			}
		}

		AnimateProjectile();
	}

	private void AnimateProjectile()
	{
		Instantiate(projectile, transform.position, transform.rotation).GetComponent<TrampolineProjectile>()
																	   .SetIsRight(true);
		Instantiate(projectile, transform.position, transform.rotation).GetComponent<TrampolineProjectile>()
																	   .SetIsRight(false);
	}
	
	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
		{
			case 1:
				damageTemp = damage;
				break;
			case 2:
				damageTemp = damage + comboBarAddedDamage;
				break;
			case 3:
			case 4:
				damageTemp = damage + 2 * comboBarAddedDamage;
				break;
		}
	}
}