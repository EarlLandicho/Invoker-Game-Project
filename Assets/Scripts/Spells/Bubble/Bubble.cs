#region

using System;
using System.Collections;
using UnityEngine;

#endregion

public class Bubble : MonoBehaviour
{
	private static Bubble instance;
	[SerializeField] private float bubbleDuration;
	[SerializeField] private float movementSpeedFactor;
	[SerializeField] private float comboBarAddedDuration;
	[SerializeField] private float comboBarAddedMovementSpeedFactor;

	private StatusEffect playerStatusEffect;
	private ComboBar comboBar;

	private float movementSpeedFactorTemp;
	private float bubbleDurationTemp;

	private void Awake()
	{
		playerStatusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();

		//Singleton
		if (instance != null)
		{
			playerStatusEffect.BecomeBubbled(movementSpeedFactor, bubbleDuration);

			ResetValues();
			
			Destroy(gameObject);
			return;
		}
		instance = this;

	}

	private void Start()
	{
		ResetValues();
		
		ComboBarCheck();
		playerStatusEffect.BecomeStatusEffectImmune(bubbleDurationTemp);
		playerStatusEffect.BecomeBubbled(movementSpeedFactorTemp, bubbleDurationTemp);
		
		StartCoroutine("Duration");
	}

	private IEnumerator Duration()
	{
		yield return new WaitForSeconds(bubbleDurationTemp);
		ResetValues();
		Destroy(gameObject);
	}

	private void ResetValues()
	{
		movementSpeedFactorTemp = movementSpeedFactor;
		bubbleDurationTemp = bubbleDuration;
	}

	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
		{
			case 2:
				movementSpeedFactorTemp += comboBarAddedMovementSpeedFactor;
				break;
			case 3:
				movementSpeedFactorTemp += 2 * comboBarAddedMovementSpeedFactor;
				break;
			case 4:
				bubbleDurationTemp += comboBarAddedDuration;
				break;
		}
	}	
	
	
}