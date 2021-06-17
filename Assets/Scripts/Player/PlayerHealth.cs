#region

using System;
using UnityEngine;

#endregion

public class PlayerHealth : Health
{
	[SerializeField] private float comboBarDecreaseValue;
	private AudioSource audioSource;
	private ComboBar comboBar;
	private float currentHealthTemp; //used for GodMode

	private new void Awake()
	{
		base.Awake();
		comboBar = FindObjectOfType<ComboBar>();
		audioSource = GameObject.Find("PlayerHitAudio").GetComponent<AudioSource>();
	}

	public event Action IsDead = delegate { };

	public override void TakeDamage(float damage, bool isStatusEffectDamage = false)
	{
		if (!isInvulnerable)
		{
			if (isStatusEffectDamage)
			{
				currentHealth -= damage;
			}
			else
			{
				damage *= damageModifier;
				currentHealth -= damage;
				audioSource.Play();
				comboBar.DecreaseComboBarLevel(comboBarDecreaseValue);
			}

			FlashWhenDamaged();
			
		}

		if (currentHealth <= 0)
		{
			Die();
			IsDead();
		}
	}

	public void SetGodModeHealth(bool isGodMode)
	{
		if (isGodMode)
		{
			currentHealthTemp = currentHealth;
			currentHealth += 10000;
		}
		else
		{
			currentHealth = currentHealthTemp;
		}
	}

	public float GetCurrentHealth()
	{
		return currentHealth;
	}

	protected override void Die()
	{
		gameObject.SetActive(false);
	}
}