using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class WingsExplosion : MonoBehaviour
{
	[SerializeField] private float explosionRadius;
	[SerializeField] private float damage;

	[UsedImplicitly]
	private void DealDamage()
	{
		Collider2D[] enemies = Physics2D.OverlapCircleAll((Vector2) transform.position, 
													   explosionRadius, 
													   1 << LayerMask.NameToLayer("Enemy"));
		foreach (Collider2D enemy in enemies)
		{
			enemy.gameObject.GetComponent<IHealth>().TakeDamage(damage);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
