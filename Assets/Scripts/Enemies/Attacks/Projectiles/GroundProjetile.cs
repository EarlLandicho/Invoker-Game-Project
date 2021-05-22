using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class GroundProjetile : EnemyProjectile
{
	[SerializeField] private Vector2 damageAreaSize;
	[SerializeField] private LayerMask allyLayers;
	[SerializeField] private LayerMask groundLayers;
	[SerializeField] private float ySpawnOffset;

	

	

	private void Start()
	{
		transform.position = ExtensionMethods.GetPlayerPosition();
		transform.position = new Vector2(transform.position.x, transform.position.y + damageAreaSize.y / 2);

		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - damageAreaSize.y / 2), -Vector2.up, 30, groundLayers);

		transform.position = new Vector2(transform.position.x, hit.point.y + ySpawnOffset);
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, damageAreaSize);
	}

	public void SetSpawnPosition(Vector2 position)
	{
		transform.position = position;
	}

	//Called in Animator
	public void DealDamage()
	{
		Collider2D[] allies = Physics2D.OverlapBoxAll(transform.position, damageAreaSize, 0f, allyLayers);

		if (allies.Length > 0)
		{
			foreach (Collider2D allyCol in allies)
			{
				allyCol.gameObject.GetComponent<IHealth>().TakeDamage(damage);
				allyCol.gameObject.GetComponent<StatusEffect>().BecomeOiled();
			}
		}
	}



}
