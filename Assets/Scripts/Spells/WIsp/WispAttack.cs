#region

using System.Collections;
using UnityEngine;

#endregion

public class WispAttack : MonoBehaviour
{
	[SerializeField] private float damage;
	[SerializeField] private float attackSpeed;
	[SerializeField] private float lifetimeDuration;
	[SerializeField] private float radius;
	[SerializeField] private GameObject projectile;
	private float attackSpeedTemp;

	private void Awake()
	{
		attackSpeedTemp = attackSpeed;
		StartCoroutine("Lifetime");
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
			int ranNum = Random.Range(0, enemies.Length);
			GameObject currentEnemy = enemies[ranNum].gameObject;
			currentEnemy.GetComponent<IHealth>().TakeDamage(damage);
			GameObject currentProjectile = Instantiate(projectile, transform.position, transform.rotation);
			currentProjectile.GetComponent<WispProjectile>().GoToEnemyPosition(currentEnemy.transform.position);
		}
	}
}