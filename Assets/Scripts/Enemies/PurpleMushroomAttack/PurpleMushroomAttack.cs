using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMushroomAttack : EnemyAttack
{
	[SerializeField] private float projectilespeed;
	[SerializeField] private GameObject projectileDestroyAnimation;
	private SpriteRenderer purpleMushroomBodySpriteRenderer;
	private Animator animator;
	private Collider2D circleCollider;

	private bool isAttacking;

	private new void Awake()
	{
		base.Awake();
		circleCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
		purpleMushroomBodySpriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}

	private void Start()
	{
		circleCollider.enabled = false;
		purpleMushroomBodySpriteRenderer.enabled = true;
		projectile.SetActive(false);
		circleCollider.isTrigger = false;
	}

	private void Update()
	{
		if (attackSpeedTemp <= 0 && !isAttacking)
		{
			Attack();
			isAttacking = true;
			attackSpeedTemp = attackSpeed;
		}
		else
		{
			attackSpeedTemp -= Time.deltaTime;
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player") ||
			other.gameObject.layer == LayerMask.NameToLayer("Ally"))
		{
			other.GetComponent<IHealth>().TakeDamage(damage);
			other.GetComponent<StatusEffect>().BecomeStunned();
			
			LeanTween.cancel(gameObject);
			
			EndAttack();
		}
	}



	//Called in Animator
	public void TransformToProjectile()
	{
		purpleMushroomBodySpriteRenderer.enabled = false;
		projectile.SetActive(true);
		circleCollider.enabled = true;
		circleCollider.isTrigger = true;

		AssaultPlayer();
	}

	private void EndAttack()
	{
		projectile.SetActive(false);
		purpleMushroomBodySpriteRenderer.enabled = true;
		circleCollider.isTrigger = false;
		isAttacking = false;
		Instantiate(projectileDestroyAnimation, transform.position, Quaternion.identity);
	}
	
	private void Attack()
	{
		animator.SetTrigger("attack");
	}
	
	private void AssaultPlayer()
	{
		Vector2 playerPosition = playerObject.transform.position;
		float time = Vector2.Distance(transform.position, playerPosition) / projectilespeed;
		LeanTween.move(gameObject, playerPosition, time).setOnComplete(EndAttack);
	}
	
	
	
	
}
