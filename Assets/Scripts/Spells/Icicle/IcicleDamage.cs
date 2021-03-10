#region

using System;
using UnityEngine;

#endregion

public class IcicleDamage : MonoBehaviour
{
	[SerializeField] private float damage;
	[SerializeField] private float comboBarAddedDamage;

	private ComboBar comboBar;
	private float damageTemp;
	private bool isColliding;

	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
		damageTemp = damage;
	}

	private void Update()
	{
		isColliding = false;
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		// Prevents multiple collisions
		if (isColliding)
		{
			return;
		}

		isColliding = true;
		if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			ComboBarCheck();
			collider.gameObject.GetComponent<IHealth>().TakeDamage(damageTemp);
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