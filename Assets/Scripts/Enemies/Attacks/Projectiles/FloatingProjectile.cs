using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FloatingProjectile : EnemyProjectile
{
	private bool isLaunchingRight;
	private bool isFacingRight;
	private float xTweenDistance;
	private float xTweenTime;
	private float ySpeed;
	private float floatDuration;
	private Rigidbody2D rigidBody;

	private new void Awake()
	{
		base.Awake();
		rigidBody = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		if (!isFacingRight)
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		
		if (isLaunchingRight)
		{
			xTweenDistance *= -1;
		}
		LeanTween.moveX(gameObject, transform.position.x  + xTweenDistance, xTweenTime).setEaseOutCirc();
		
		Invoke(nameof(DestroyWithAnimation), floatDuration);
	}

	private void Update()
	{
		rigidBody.velocity = new Vector2(rigidBody.velocity.x, ySpeed);
	}
	
	protected override void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player") ||
			other.gameObject.layer == LayerMask.NameToLayer("Ally"))
		{
			other.GetComponent<IHealth>().TakeDamage(damage);
			other.GetComponent<StatusEffect>().BecomePoisoned();
			animator.SetTrigger("hasHitSomething");
		}
		else if (other.gameObject.layer == LayerMask.NameToLayer("Ground") ||
				 other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
		{
			animator.SetTrigger("hasHitSomething");
		}
	}

	public void SetIsLaunchingRight(bool isRight)
	{
		isLaunchingRight = isRight;
	}

	public void SetXTweenDistance(float distance)
	{
		xTweenDistance = distance;
	}

	public void SetXTweenTime(float time)
	{
		xTweenTime = time;
	}

	public void SetYSpeed(float speed)
	{
		ySpeed = speed;
	}

	public void SetFloatDuration(float duration)
	{
		floatDuration = duration;
	}

	public void SetIsFacingRight(bool isRight)
	{
		isFacingRight = isRight;
	}

	//Called in Animator
	public override void StopMovement()
	{
		LeanTween.cancel(gameObject);
		rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
	}

}
