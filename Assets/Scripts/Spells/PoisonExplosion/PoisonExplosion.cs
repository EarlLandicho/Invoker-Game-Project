#region

using UnityEngine;

#endregion

public class PoisonExplosion : MonoBehaviour
{
	[SerializeField] private float explosionRadius;
	[SerializeField] private float comboBarAddedExplosionRadius;
	[SerializeField] private float impactDamage;
	[SerializeField] private float comboBarAddedImpactDamage;
	[SerializeField] private float poisonBubbleDamageSpeed;
	[SerializeField] private float poisonBubbleDuration;
	private float cloudPoisonCheckTimer;
	private ComboBar comboBar;
	private float impactDamageTemp;

	private void Awake()
	{
		cloudPoisonCheckTimer = poisonBubbleDamageSpeed;
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void Start()
	{
		impactDamageTemp = impactDamage;
		ComboBarCheck();
		LeanTween.moveY(gameObject, gameObject.transform.position.y + .05f, 1.5f).setEaseInOutSine().setLoopPingPong();

		Destroy(gameObject, poisonBubbleDuration);
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
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius, 1 << LayerMask.NameToLayer("Enemy"));
		if (enemies.Length > 0)
		{
			foreach (Collider2D enemyCol in enemies)
			{
				enemyCol.gameObject.GetComponent<IHealth>().TakeDamage(impactDamageTemp);
				Debug.Log(impactDamageTemp);
				enemyCol.gameObject.GetComponent<StatusEffect>().BecomePoisoned();
			}
		}
	}

	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
		{
			case 1:
				impactDamageTemp = impactDamage;
				break;
			case 2:
				impactDamageTemp = impactDamage + comboBarAddedImpactDamage;
				break;
			case 3:
				impactDamageTemp = impactDamage + 2 * comboBarAddedImpactDamage;
				break;
			case 4:
				explosionRadius += comboBarAddedExplosionRadius;
				transform.localScale = new Vector3(transform.localScale.x + comboBarAddedExplosionRadius * 2,
												   transform.localScale.y + comboBarAddedExplosionRadius * 2,
												   transform.localScale.z);
				impactDamageTemp = impactDamage + 2 * comboBarAddedImpactDamage;
				break;
		}
	}
}