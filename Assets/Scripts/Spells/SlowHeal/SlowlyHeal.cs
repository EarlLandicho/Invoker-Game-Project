#region

using System;
using System.Collections;
using UnityEngine;

#endregion

public class SlowlyHeal : MonoBehaviour
{
	[SerializeField] private float healTotalAmount;
	[SerializeField] private float healDuration;
	[SerializeField] private float comboBarAddedHeal;
	[SerializeField] private float comboBarDurationDecrease;

	private float healTotalAmountTemp;

	private float healDurationTemp;
	
	private StatusEffect statusEffect;
	
	private ComboBar comboBar;
	private void Awake()
	{
		statusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void Start()
	{
		healTotalAmountTemp = healTotalAmount;
		healDurationTemp = healDuration;
		ComboBarCheck();
		statusEffect.Dispel();
		statusEffect.TickHealing(healTotalAmountTemp, healDurationTemp);
		StartCoroutine("DestroyThis");
	}

	private IEnumerator DestroyThis()
	{
		yield return new WaitForSeconds(healDuration);
		Destroy(gameObject);
	}

	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
		{
			case 1:
				healTotalAmountTemp += comboBarAddedHeal;
				break;
			case 3:
				healTotalAmountTemp += 2 * comboBarAddedHeal;
				break;
			case 4:
				healTotalAmountTemp += 2 * comboBarAddedHeal;
				healDurationTemp -= comboBarDurationDecrease;
				break;
		}
	}
	
	
	
	
}