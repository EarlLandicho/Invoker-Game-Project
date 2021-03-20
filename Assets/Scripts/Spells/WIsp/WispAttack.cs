#region

using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WispAttack : MonoBehaviour
{
	[SerializeField] private float damage;
	[SerializeField] private float comboBarAddedDamage;
	[SerializeField] private float attackSpeed;
	[SerializeField] private float lifetimeDuration;
	[SerializeField] private float radius;
	[SerializeField] private GameObject projectile;

	private float attackSpeedTemp;

	private ComboBar comboBar;
	private int comboBarStage;
	private float damageTemp;


	private void Awake()
	{
		StartCoroutine("Lifetime");
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();

	}

	private void Start()
	{
		attackSpeedTemp = attackSpeed;
		comboBarStage = comboBar.GetComboBarStage();
	}

	private void Update()
	{
		if (attackSpeedTemp > 0)
		{
			attackSpeedTemp -= Time.deltaTime;
		}
		else
		{
			attackSpeedTemp = attackSpeed;
			Attack();
		}
	}

	private void OnDrawGizmos()
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, radius);
	}

	private IEnumerator Lifetime()
	{
		yield return new WaitForSeconds(lifetimeDuration);
		Destroy(gameObject);
	}

	private void Attack()
	{
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, 1 << LayerMask.NameToLayer("Enemy"));
		if (enemies.Length > 0)
		{
			ComboBarCheck();
			int ranNum = Random.Range(0, enemies.Length);
			GameObject currentEnemy = enemies[ranNum].gameObject;
			currentEnemy.GetComponent<IHealth>().TakeDamage(damageTemp);
			Debug.Log(damageTemp);
			GameObject currentProjectile = Instantiate(projectile, transform.position, transform.rotation);
			currentProjectile.GetComponent<WispProjectile>().GoToEnemyPosition(currentEnemy.transform.position);
		}
	}

	private void ComboBarCheck()
	{
		switch (comboBarStage)
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

#endregion