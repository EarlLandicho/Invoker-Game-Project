#region

using System;
using UnityEngine;

#endregion

public class LavaBurstProjectile : MonoBehaviour
{
	[SerializeField] private float damage;
	[SerializeField] private GameObject explosionAnimation;
	[SerializeField] private float comboBarAddedDamage;

	private ComboBar comboBar;
	private float damageTemp;

	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			ComboBarCheck();
			col.gameObject.GetComponent<IHealth>().TakeDamage(damageTemp);
			col.gameObject.GetComponent<StatusEffect>().BecomeBurned();
			Explode();
		}

		if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			Explode();
		}
	}

	private void Explode()
	{
		Instantiate(explosionAnimation, transform.position, transform.rotation);
		Destroy(gameObject);
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