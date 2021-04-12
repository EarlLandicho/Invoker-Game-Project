#region

using System;
using UnityEngine;

#endregion

public class ComboBar : MonoBehaviour
{
	[SerializeField] private float comboLevelDrainFactor = 1;
	[SerializeField] private GameObject powerUpAnimation;

	private GameObject player;
	private int comboBarStage;
	private float currentBarLevel;

	private int comboBarStageTemp;

	private void Awake()
	{
		
		player = GameObject.Find("Player");
	}

	private void Start()
	{
		currentBarLevel = 0;
		comboBarStageTemp = 1;
		comboBarStage = 1;
	}

	private void Update()
	{
		DrainBarLevel();
		BarLevelMaxReachedCheck();
		ComboBarStageCheck();
	}

	public float GetComboBarLevel()
	{
		return currentBarLevel;
	}

	public int GetComboBarStage()
	{
		return comboBarStage;
	}

	public void IncreaseComboBarLevel(float increaseValue)
	{
		currentBarLevel += increaseValue;
	}

	public void DecreaseComboBarLevel(float decreaseValue)
	{
		currentBarLevel -= decreaseValue;
	}

	private void ComboBarStageCheck()
	{
		if (currentBarLevel < 25f)
		{
			comboBarStage = 1;
		}
		else if (ExtensionMethods.IsBetweenTwoValues(25f, 50f, currentBarLevel))
		{
			comboBarStage = 2;
		}
		else if (ExtensionMethods.IsBetweenTwoValues(50f, 75f, currentBarLevel))
		{
			comboBarStage = 3;
		}
		else if (currentBarLevel >= 75f)
		{
			comboBarStage = 4;
		}
		else
		{
			Debug.LogError("Something wrong with the stages in the combo bar. Level is outside of 1-100");
		}

		PowerUpAnimation();
	}

	private void PowerUpAnimation()
	{
		if (comboBarStageTemp < comboBarStage)
		{
			Instantiate(powerUpAnimation, player.transform.position, Quaternion.identity);
			comboBarStageTemp = comboBarStage;
		}

		if (comboBarStageTemp > comboBarStage)
		{
			comboBarStageTemp = comboBarStage;
		}
	}

	private void DrainBarLevel()
	{
		if (currentBarLevel > 0)
		{
			currentBarLevel -= Time.deltaTime * comboLevelDrainFactor;
		}
	}

	private void BarLevelMaxReachedCheck()
	{
		if (currentBarLevel > 100)
		{
			currentBarLevel = 100;
		}
	}
}