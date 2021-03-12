#region

using UnityEngine;

#endregion

public class GroundSlamDamage : MonoBehaviour
{
	[SerializeField] private Vector2 size = new Vector2(0, 0);
	[SerializeField] private float damage;
	[SerializeField] private GameObject slamParticleEffect;
	[SerializeField] private float comboBarAddedDamage;
	private PlayerJump playerJump;
	private ComboBar comboBar;
	private float damageTemp;

	private void Awake()
	{
		playerJump = GameObject.Find("Player").GetComponent<PlayerJump>();
		if (FindObjectOfType(typeof(WingsMovement)) != null)
		{
			WingsMovement component = (WingsMovement) FindObjectOfType(typeof(WingsMovement));
			component.CancelFlight();
		}
		
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
		damageTemp = damage;
	}

	private void Update()
	{
		if (playerJump.GetIsGrounded())
		{
			Collider2D[] enemies = Physics2D.OverlapBoxAll(transform.position, size, 0, 1 << LayerMask.NameToLayer("Enemy"));
			foreach (Collider2D enemy in enemies)
			{
				ComboBarCheck();
				enemy.gameObject.GetComponent<IHealth>().TakeDamage(damageTemp);

				StatusEffect statusEffect = enemy.gameObject.GetComponent<StatusEffect>();
				statusEffect.BecomePoisoned();
				statusEffect.BecomeOiled();

				if (comboBar.GetComboBarStage() == 4)
				{
					statusEffect.BecomeStunned();
				}
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
	
	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
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