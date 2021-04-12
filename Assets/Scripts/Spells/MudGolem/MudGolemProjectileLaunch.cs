#region

using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

#endregion

public class MudGolemProjectileLaunch : MonoBehaviour
{
	[SerializeField] private GameObject projectile;
	[SerializeField] private float attackSpeed;
	[SerializeField] private float attackDelay;
	[SerializeField] private float comboBarAttackSpeedFactor;
	
	private Animator animator;
	private float attackRangeRadius;
	private float attackSpeedTemp;
	private bool canAttack;
	private bool isAttacking;
	private MovementFlip movementFlip;
	private MudGolem mudGolem;
	private GameObject targetGameObject;
	private Vector3 target;
	
	private ComboBar comboBar;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		movementFlip = GetComponent<MovementFlip>();
		mudGolem = GetComponent<MudGolem>();
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void Start()
	{
		ComboBarCheck();
		attackRangeRadius = transform.GetChild(0).GetComponent<CircleCollider2D>().radius;
	}

	private void Update()
	{
		if (attackSpeedTemp > 0)
		{
			if (!canAttack && !isAttacking)
			{
				attackSpeedTemp -= Time.deltaTime;
			}
		}
		else
		{
			canAttack = true;
			attackSpeedTemp = attackSpeed;
		}
	}

	private void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy") && canAttack)
		{
			AttackRandomEnemyInRange();
		}
	}

	// Called in Animator
	[UsedImplicitly]
	public void ThrowBoulderProjectile()
	{
		GameObject projectileObject = Instantiate(projectile, transform.position, transform.rotation);
		try
		{
			projectileObject.GetComponent<MudGolemProjectile>().SetTarget(targetGameObject.transform.position);
		}
		catch (Exception e)
		{
			Debug.Log("MudGolem target is " + targetGameObject);
		}
		
		projectileObject.GetComponent<MudGolemProjectile>().SetMoxGolemRange(attackRangeRadius);
		mudGolem.SetCanMove(true);
		isAttacking = false;
	}

	private void AttackRandomEnemyInRange()
	{
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRangeRadius, 1 << LayerMask.NameToLayer("Enemy"));
		if (enemies.Length > 0)
		{
			int ranNum = Random.Range(0, enemies.Length);
			targetGameObject = enemies[ranNum].gameObject;
			target = targetGameObject.transform.position;
			StartCoroutine("DelayAttack");
		}
	}

	private IEnumerator DelayAttack()
	{
		canAttack = false;
		isAttacking = true;
		mudGolem.SetCanMove(false);
		yield return new WaitForSeconds(attackDelay);
		FaceCorrectDirection();
		animator.SetTrigger("attack");
	}

	private void FaceCorrectDirection()
	{
		if (target.x < transform.position.x)
		{
			movementFlip.FaceLeft();
		}
		else
		{
			movementFlip.FaceRight();
		}
	}
	
	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
		{
			case 4:
				attackSpeed /= comboBarAttackSpeedFactor;
				attackDelay /= comboBarAttackSpeedFactor;
				break;
		}
	}
}