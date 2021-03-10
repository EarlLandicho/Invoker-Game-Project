#region

using JetBrains.Annotations;
using UnityEngine;

#endregion

public class LightningCloudSpawn : MonoBehaviour
{
	[SerializeField] private float damage;
	[SerializeField] private float comboBarAddedDamage;
	[SerializeField] private Vector2 centerOffSet = new Vector2(0, 0);
	[SerializeField] private Vector2 size = new Vector2(0, 0);
	[SerializeField] private LayerMask layerMask;

	private ComboBar comboBar;
	private float damageTemp;
	
	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
		damageTemp = damage;
	}
	private void Start()
	{
		const float yOffSet = .40f;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 500f, layerMask);
		transform.position = hit.point + new Vector2(0, yOffSet);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube((Vector2) transform.position + centerOffSet, size);
	}

	// Called in Animator
	[UsedImplicitly]
	public void DealDamage()
	{
		Collider2D[] enemies = Physics2D.OverlapBoxAll((Vector2) transform.position + centerOffSet, 
													   size, 
													   0,
													   1 << LayerMask.NameToLayer("Enemy"));
		foreach (Collider2D enemy in enemies)
		{
			ComboBarCheck();
			enemy.gameObject.GetComponent<IHealth>().TakeDamage(damageTemp);
			enemy.gameObject.GetComponent<StatusEffect>().BecomeStunned();
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