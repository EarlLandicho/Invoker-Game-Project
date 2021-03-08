#region

using UnityEngine;

#endregion

public class SolarFlare : MonoBehaviour
{
	[SerializeField] private float projectileDestroyRadius;
	[SerializeField] private float enemyBurnRadius;

	private void Start()
	{
		var enemies =
			Physics2D.OverlapCircleAll(transform.position, enemyBurnRadius, 1 << LayerMask.NameToLayer("Enemy"));
		foreach (var enemy in enemies)
		{
			enemy.gameObject.GetComponent<StatusEffect>().BecomeBurned();
		}

		//StartCoroutine("Flash");
		LeanTween.value(gameObject, 1f, 0, .8f).setEaseInOutSine().setOnUpdate(value =>
																			   {
																				   var spriteRenderer =
																					   gameObject
																						  .GetComponent<SpriteRenderer
																						   >();
																				   var newColor = spriteRenderer.color;
																				   newColor.a = value;
																				   spriteRenderer.color = newColor;
																			   }).setOnComplete(OnComplete);
		var projectiles = Physics2D.OverlapCircleAll(transform.position, projectileDestroyRadius,
													 1 << LayerMask.NameToLayer("Enemy Projectile"));
		foreach (var projectile in projectiles)
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