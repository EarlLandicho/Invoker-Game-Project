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
	private float distX;
	private float distY;
	private float distXY;
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
		
		xPosStart = startPosition.x;
		xPosTarget = targetPositon.x;
		distX = xPosTarget - xPosStart;
		distY = startPosition.y - targetPositon.y;
		Debug.Log(distY);

	}

	private void Update()
	{
		nextXPos = Mathf.MoveTowards(transform.position.x, xPosTarget, Mathf.Clamp(speed / (Mathf.Abs(distY) + .01f), .1f, 5f) * Time.deltaTime);
		baseY = Mathf.Lerp(startPosition.y, targetPositon.y, (nextXPos - xPosStart) / distX);
		arc = arcHeight * (nextXPos - xPosStart) * (nextXPos - xPosTarget) / (-0.25f * distX * distX);
		transform.position = new Vector3(nextXPos, baseY + arc, 0);
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
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, damageRadius,
														  1 << LayerMask.NameToLayer("Enemy"));
		foreach (Collider2D enemy in enemies)
		{
			enemy.gameObject.GetComponent<IHealth>().TakeDamage(damage);
			enemy.gameObject.GetComponent<StatusEffect>().BecomeOiled();
		}

		Instantiate(explosionAnimation, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}