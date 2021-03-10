#region

using UnityEngine;

#endregion

public class SolarFlare : MonoBehaviour
{
	[SerializeField] private float projectileDestroyRadius;
	[SerializeField] private float enemyBurnRadius;

	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, enemyBurnRadius, 1 << LayerMask.NameToLayer("Enemy"));
		foreach (Collider2D enemy in enemies)
		{
			enemy.gameObject.GetComponent<StatusEffect>().BecomeBurned();
		}

		LeanTween.value(gameObject, spriteRenderer.color.a, 0, .8f).setEaseInOutSine().setOnUpdate(onUpdate: value =>
																											 {
																												 SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
																												 Color newColor = spriteRenderer.color;
																												 newColor.a = value;
																												 spriteRenderer.color = newColor;
																											 }).setOnComplete(OnComplete);

		Collider2D[] projectiles = Physics2D.OverlapCircleAll(transform.position, projectileDestroyRadius,
															  1 << LayerMask.NameToLayer("Enemy Projectile"));
		foreach (Collider2D projectile in projectiles)
		{
			projectile.gameObject.GetComponent<EnemyProjectile>().DestroyWithAnimation();
		}
	}

	private void OnDrawGizmos()
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, projectileDestroyRadius);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, enemyBurnRadius);
	}

	private void OnComplete()
	{
		Destroy(gameObject);
	}
}