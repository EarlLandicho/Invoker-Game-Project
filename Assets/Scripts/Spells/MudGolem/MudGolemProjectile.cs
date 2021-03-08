#region

using UnityEngine;

#endregion

public class MudGolemProjectile : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float arcHeight;
	[SerializeField] private float damageRadius;
	[SerializeField] private float damage;
	[SerializeField] private GameObject explosionAnimation;
	private float arc;
	private float baseY;
	private float dist;
	private float maxGolemRange;
	private float nextXPos;
	private Vector3 startPosition;
	private Vector3 targetPositon;
	private float xPosStart;
	private float xPosTarget;

	private void Start()
	{
		startPosition = transform.position;
		arcHeight = Mathf.Abs(arcHeight * (targetPositon.x - startPosition.x) / maxGolemRange);
	}

	private void Update()
	{
		xPosStart = startPosition.x;
		xPosTarget = targetPositon.x;
		dist = xPosTarget - xPosStart;
		nextXPos = Mathf.MoveTowards(transform.position.x, xPosTarget, speed * Time.deltaTime);
		baseY = Mathf.Lerp(startPosition.y, targetPositon.y, (nextXPos - xPosStart) / dist);
		arc = arcHeight * (nextXPos - xPosStart) * (nextXPos - xPosTarget) / (-0.25f * dist * dist);
		transform.position = new Vector3(nextXPos, baseY + arc, transform.position.z);
		if (transform.position == targetPositon)
		{
			ExplosionDamage();
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, damageRadius);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			ExplosionDamage();
		}
	}

	public void SetTarget(Vector3 target)
	{
		targetPositon = target;
	}

	public void SetMoxGolemRange(float range)
	{
		maxGolemRange = range;
	}

	private void ExplosionDamage()
	{
		var enemies = Physics2D.OverlapCircleAll(transform.position, damageRadius,
												 1 << LayerMask.NameToLayer("Enemy"));
		foreach (var enemy in enemies)
		{
			enemy.gameObject.GetComponent<IHealth>().TakeDamage(damage);
			enemy.gameObject.GetComponent<StatusEffect>().BecomeOiled();
		}

		Instantiate(explosionAnimation, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}