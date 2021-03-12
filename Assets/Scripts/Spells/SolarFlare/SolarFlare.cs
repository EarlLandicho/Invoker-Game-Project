#region

using UnityEngine;

#endregion

public class SolarFlare : MonoBehaviour
{
	[SerializeField] private float projectileDestroyRadius;
	[SerializeField] private float enemyBurnRadius;
	[SerializeField] private float comboBarBurnAddedRadius;

	[SerializeField] private GameObject solarFlareAnimation;
	

	private SpriteRenderer spriteRenderer;
	
	private ComboBar comboBar;
	private float enemyBurnRadiusTemp;
	private Vector3 animationSize;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void Start()
	{
		ComboBarCheck();
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, enemyBurnRadiusTemp, 1 << LayerMask.NameToLayer("Enemy"));
		foreach (Collider2D enemy in enemies)
		{
			enemy.gameObject.GetComponent<StatusEffect>().BecomeBurned();

			if (comboBar.GetComboBarStage() == 4)
			{
				enemy.gameObject.GetComponent<StatusEffect>().BecomeStunned();
			}
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

		GameObject animation = Instantiate(solarFlareAnimation, transform.position, transform.rotation);
		animation.transform.localScale = animationSize;
	}

	private void OnDrawGizmos()
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, projectileDestroyRadius);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, enemyBurnRadiusTemp);
	}

	private void OnComplete()
	{
		Destroy(gameObject);
	}
	
	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
		{
			case 1:
				enemyBurnRadiusTemp = enemyBurnRadius;
				animationSize = new Vector3(1, 1);
				break;
			case 2:
				enemyBurnRadiusTemp = enemyBurnRadius + comboBarBurnAddedRadius;
				animationSize = new Vector3(1.3f, 1.3f);
				break;
			case 3:
			case 4:
				enemyBurnRadiusTemp = enemyBurnRadius + 2 * comboBarBurnAddedRadius;
				animationSize = new Vector3(1.6f, 1.6f);
				break;
		}
	}
}