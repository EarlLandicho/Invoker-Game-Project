#region

using UnityEngine;

#endregion

public class PoisonExplosion : MonoBehaviour
{
	[SerializeField] private float explosionRadius;
	[SerializeField] private float impactDamage;
	[SerializeField] private float poisonBubbleDamageSpeed;
	[SerializeField] private float poisonBubbleDuration;
	private float cloudPoisonCheckTimer;

	private void Awake()
	{
		cloudPoisonCheckTimer = poisonBubbleDamageSpeed;
		Destroy(gameObject, poisonBubbleDuration);
	}

	private void Start()
	{
		LeanTween.moveY(gameObject, gameObject.transform.position.y + .05f, 1.5f).setEaseInOutSine().setLoopPingPong();
	}

	private void Update()
	{
		if (cloudPoisonCheckTimer > 0)
		{
			cloudPoisonCheckTimer -= Time.deltaTime;
		}
		else
		{
			cloudPoisonCheckTimer = poisonBubbleDamageSpeed;
			PoisonArea();
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}

	private void PoisonArea()
	{
		Collider2D[] enemies =
			Physics2D.OverlapCircleAll(transform.position, explosionRadius, 1 << LayerMask.NameToLayer("Enemy"));
		if (enemies.Length > 0)
		{
			foreach (Collider2D enemyCol in enemies)
			{
				enemyCol.gameObject.GetComponent<IHealth>().TakeDamage(impactDamage);
				enemyCol.gameObject.GetComponent<StatusEffect>().BecomePoisoned();
			}
		}
	}
}