#region

using System;
using UnityEngine;

#endregion

public class TornadoHit : MonoBehaviour
{
	[SerializeField] private float damage;
	[SerializeField] private float comboBarAddedDamage;
	
	private ComboBar comboBar;
	private float damageTemp;

	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
		damageTemp = damage;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			col.gameObject.GetComponent<IHealth>().TakeDamage(damageTemp);
			col.gameObject.GetComponent<StatusEffect>().BecomeStunned();
		}

		if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			Destroy(gameObject);
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