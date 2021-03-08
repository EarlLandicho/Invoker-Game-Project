#region

using UnityEngine;

#endregion

public class GroundSlamDamage : MonoBehaviour
{
	[SerializeField] private Vector2 size = new Vector2(0, 0);
	[SerializeField] private float damage;
	[SerializeField] private GameObject slamParticleEffect;
	private PlayerJump playerJump;

	private void Awake()
	{
		playerJump = GameObject.Find("Player").GetComponent<PlayerJump>();
		if (FindObjectOfType(typeof(WingsMovement)) != null)
		{
			var component = (WingsMovement) FindObjectOfType(typeof(WingsMovement));
			component.CancelFlight();
		}
	}

	private void Update()
	{
		if (playerJump.GetIsGrounded())
		{
			var enemies = Physics2D.OverlapBoxAll(transform.position, size, 0, 1 << LayerMask.NameToLayer("Enemy"));
			foreach (var enemy in enemies)
			{
				enemy.gameObject.GetComponent<IHealth>().TakeDamage(damage);
				enemy.gameObject.GetComponent<StatusEffect>().BecomePoisoned();
				enemy.gameObject.GetComponent<StatusEffect>().BecomeOiled();
			}

			Instantiate(slamParticleEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube((Vector2) transform.position, size);
	}
}