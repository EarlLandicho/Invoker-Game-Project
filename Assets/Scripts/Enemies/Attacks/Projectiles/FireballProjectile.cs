using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : EnemyProjectile
{

	[SerializeField] private GameObject fireTrailAnimation;

	private void Start()
	{
		float zRotation = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
	}
	
	
	protected override void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player") ||
			other.gameObject.layer == LayerMask.NameToLayer("Ally"))
		{
			other.GetComponent<IHealth>().TakeDamage(damage);
			other.GetComponent<StatusEffect>().BecomeBurned();
			
			animator.SetTrigger("hasHitSomething");
			Destroy(fireTrailAnimation);
		}
		else if (other.gameObject.layer == LayerMask.NameToLayer("Ground") ||
				 other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
		{
			animator.SetTrigger("hasHitSomething");
			Destroy(fireTrailAnimation);

		}
	}
}
