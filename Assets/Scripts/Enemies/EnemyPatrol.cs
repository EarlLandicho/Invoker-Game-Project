﻿#region

using UnityEngine;

#endregion

[RequireComponent(typeof(EnemyMovement))]
public class EnemyPatrol : MonoBehaviour
{
	[SerializeField] private Vector2 patrolPoint1 = new Vector2(0, 0);
	[SerializeField] private Vector2 patrolPoint2 = new Vector2(0, 0);
	private EnemyMovement enemyMovement;
	private bool isFacingRight = true;
	private Rigidbody2D rb;
	private float speed;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		enemyMovement = GetComponent<EnemyMovement>();
	}

	private void Update()
	{
		PatrolCheck();
		speed = enemyMovement.GetMovementSpeed();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawSphere(new Vector2(patrolPoint1.x, gameObject.transform.position.y), .1f);
		Gizmos.DrawSphere(new Vector2(patrolPoint2.x, gameObject.transform.position.y), .1f);
	}

	private void PatrolCheck()
	{
		//if patrol1 is on the right of patrol2. Otherwise go to else statement
		if (patrolPoint1.x >= patrolPoint2.x)
		{
			if (isFacingRight)
			{
				rb.velocity = new Vector2(speed, rb.velocity.y);
				if (transform.position.x - patrolPoint1.x > 0.1f)
				{
					isFacingRight = !isFacingRight;
				}
			}
			else
			{
				rb.velocity = new Vector2(-speed, rb.velocity.y);
				if (transform.position.x - patrolPoint2.x < -0.1f)
				{
					isFacingRight = !isFacingRight;
				}
			}
		}
		else
		{
			if (isFacingRight)
			{
				rb.velocity = new Vector2(speed, rb.velocity.y);
				if (transform.position.x - patrolPoint2.x >= Mathf.Epsilon)
				{
					isFacingRight = !isFacingRight;
				}
			}
			else
			{
				rb.velocity = new Vector2(-speed, rb.velocity.y);
				if (transform.position.x - patrolPoint1.x <= Mathf.Epsilon)
				{
					isFacingRight = !isFacingRight;
				}
			}
		}
	}
}