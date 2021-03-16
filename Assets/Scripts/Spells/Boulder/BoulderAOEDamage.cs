#region

using UnityEngine;

#endregion

public class BoulderAOEDamage : MonoBehaviour
{
	[SerializeField] private float damage;
	[SerializeField] private float radiusRange;
	[SerializeField] private float comboBarAddedDamage;

	private ComboBar comboBar;
	private float damageTemp;

	private void Awake()
	{
		transform.parent.GetComponent<BoulderDestroy>().BoulderDestroyed += DealAOEDamage;

		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
		damageTemp = damage;
	}

	private void Start()
	{
		damageTemp = damage;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, radiusRange);
	}

	private void DealAOEDamage()
	{
		//need to do bit shift for the last parameter to work
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radiusRange,
														  1 << LayerMask.NameToLayer("Enemy"));
		foreach (Collider2D enemy in enemies)
		{
			ComboBarCheck();
			enemy.gameObject.GetComponent<IHealth>().TakeDamage(damageTemp);
		}
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